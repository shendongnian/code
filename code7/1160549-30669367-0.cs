    using System.Text;
    using System.Windows.Forms;
    using System.Net;
    using System.IO;
    
    namespace FTPTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                string localPath = @"C:\Temp\navigazione-privata.pdf";
                string ftpIPAddress = "xxx.xxx.xxx.xxx";
                string remoteFilepath = "/userdownloads/navigazione-privata.pdf";
    
                string ftpPath = "ftp://" + ftpIPAddress + remoteFilepath;
    
                using (WebClient request = new WebClient())
                {
                    request.Credentials = new NetworkCredential("username", "password");
                    byte[] fileData = request.DownloadData(ftpPath);
    
                    using (FileStream file = File.Create(localPath))
                    {
                        file.Write(fileData, 0, fileData.Length);
                        file.Close();
                    }
                    MessageBox.Show("Requested file downloaded");
                }
            }
        }
    }
