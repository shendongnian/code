    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Tasks
    {
        public partial class Form1 : Form
        {
            CancellationTokenSource cts;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                MessageBox.Show(this,"This button still works :)");
            }
    
            private async void button1_Click(object sender, EventArgs e)
            {
                cts = new CancellationTokenSource();
    
                await CreateTask();
            }
    
            private async Task CreateTask()
            {
                Progress<string> mProgress;
                Action<string> progressTarget = ReportProgress;
                mProgress = new Progress<string>(progressTarget);
    
                string result = await MyProcess(mProgress);
    
                MessageBox.Show(this, result);
            }
    
            private Task<string> MyProcess(IProgress<string> myProgress)
            {
                return Task.Run(() =>
                {
    
                    myProgress.Report("It Works..");
                       
    
                    return "Yes it really does work...";
    
                }, cts.Token);
            }
    
            private void ReportProgress(string message)
            {
                //typically to update a progress bar or whatever
                textBox1.Text = message;
            }
        }
    }
