    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            DirectoryInfo[] MySubDirs;
            BackgroundWorker w;
            int count;
    
            private void button1_Click(object sender, EventArgs e)
            {
                button1.Enabled = false;
                count = 0;
                w = new BackgroundWorker();
                w.DoWork += w_DoWork;
                w.ProgressChanged += w_ProgressChanged;
                w.WorkerReportsProgress = true;
                w.RunWorkerCompleted += w_RunWorkerCompleted;
                w.RunWorkerAsync();
                
            }
    
            void w_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                button1.Enabled = true;
            }
    
            void w_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                label1.Text = e.UserState.ToString();
            }
    
            void w_DoWork(object sender, DoWorkEventArgs e)
            {
                MySubDirs = GetDirectories("d:\\prj").ToArray();
            }
    
            private List<DirectoryInfo> GetDirectories(string basePath)
            {
                IEnumerable<string> str = MyGetDirectories(basePath);
    
                List<DirectoryInfo> l = new List<DirectoryInfo>();
                l.Add(new DirectoryInfo(basePath));
    
                IEnumerable<DirectoryInfo> dirs = str.Select(a => new DirectoryInfo(a));
                l.AddRange(dirs);
    
                return l;
            }
            //not static so we can report progress from it
            private IEnumerable<string> MyGetDirectories(string basePath)
            {
                try
                {
                    string[] dirs = Directory.GetDirectories(basePath);
                    count += dirs.Length;
                    w.ReportProgress(0, count.ToString());
                    return dirs.Union(dirs.SelectMany(dir => MyGetDirectories(dir)));
                }
                catch (UnauthorizedAccessException)
                {
                    return Enumerable.Empty<string>();
                }
            }
        }
    }
