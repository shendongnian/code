    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.RunWorkerAsync();
            }
    
            private void GetIPInfo()
            {
                try
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = "ipconfig.exe";
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.OutputDataReceived += (sender, e) => 
                         backgroundWorker1.ReportProgress(0, e.Data);
                    proc.Start();
                    proc.BeginOutputReadLine();
                    proc.WaitForExit();
                }
                catch (Exception err)
                {
                    string myerr = err.ToString();
                }
            }
    
            private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                GetIPInfo();
            }
    
            private void backgroundWorker1_ProgressChanged(object sender,
                                                           ProgressChangedEventArgs e)
            {
                if (!(e.UserState == null))
                {                
                    listBox1.Items.Add(e.UserState.ToString()); 
                }
            }
        }
    }
