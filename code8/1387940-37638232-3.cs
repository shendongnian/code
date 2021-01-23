    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Tasks
    {
        public partial class Form1 : Form
        {
            //Just incase you need to stop the current task
            CancellationTokenSource cts;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                //showing that the form is still working
                MessageBox.Show(this,"This button still works :)");
            }
    
            private async void button1_Click(object sender, EventArgs e)
            {
                cts = new CancellationTokenSource();
    
                await CreateTask();
            }
    
            private async Task CreateTask()
            {
                //Create a progress object that can be used within the task
                Progress<string> mProgress; //you can set this to Int for ProgressBar
                //Set the Action to a function that will catch the progress sent within the task
                Action<string> progressTarget = ReportProgress;
                //Your new Progress with the included action function
                mProgress = new Progress<string>(progressTarget); 
    
                //start your task
                string result = await MyProcess(mProgress);
    
                MessageBox.Show(this, result);
            }
    
            //notice the myProgress this can be used within your task to report back to UI thread.
            private Task<string> MyProcess(IProgress<string> myProgress)
            {
                return Task.Run(() =>
                {
                    //here you will sen out to your UI thread whatever text you want.
                    //typically used for progress bar.
                    myProgress.Report("It Works..");
                    //your tasks return
                    return "Yes it really does work...";
    
                }, cts.Token);
            }
    
            private void ReportProgress(string message)
            {
                //typically to update a progress bar or whatever
                //this is where you Update your UI thread with text from within the Task.
                textBox1.Text = message;
            }
        }
    }
