using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace ftpWindows
{
    public partial class Form1 : Form
    {
        private bool localFolderTag = false;

        
        private TcpClient cmdServer;
        private TcpClient dataServer;
        private NetworkStream cmdStrmWtr;
        private StreamReader cmdStrmRdr;
        private NetworkStream dataStrmWtr;
        private StreamReader dataStrmRdr;
        private String cmdData;
        private byte[] szData;
        private const String CRLF = "\r\n";
        


        public Form1()
        {
            InitializeComponent();
        }

        private void folder_TextChanged(object sender, EventArgs e)
        {
            string path = folder.Text;
            string pattern = "*";
            try
            {
                List<FileInfo> folder = new DirectoryInfo(path).GetFiles(pattern).ToList();
                this.listBox1.Items.Clear();
                foreach (FileInfo file in folder)
                {
                    this.listBox1.Items.Add(file.Name);
                }
                localFolderTag = true;
            }
            catch
            {
                this.listBox1.Items.Clear();
                this.listBox1.Items.Add("文件夹打开失败");
                localFolderTag = false;
            }
            
        }

        private void selectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择本地文件夹";  //提示的文字
            if (folder.ShowDialog() == DialogResult.OK)
            {
                this.folder.Text = folder.SelectedPath;
            }
        }
    }
}
