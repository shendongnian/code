     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                backgroundWorker1.DoWork += backgroundWorker1_DoWork;
                backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            }
    
            void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                button1.Enabled = true;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                button1.Enabled = false;
                backgroundWorker1.RunWorkerAsync();
            }
    
            void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                label1.Text = e.ProgressPercentage.ToString();
            }
    
            void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                FakeCountingWork();
            }
    
    
            private void FakeCountingWork()
            {
                int totalNumber = 100;
                int progressCounter = 0;
                while (progressCounter < totalNumber)
                {
                    int fakecounter = 0;
                    for (int x = 0; x < 100000000; x++)
                    {
                        fakecounter++;
                    }
                    progressCounter++;
                    backgroundWorker1.ReportProgress(progressCounter);
                }
            }
        }
