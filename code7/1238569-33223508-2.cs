    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void buttonStart_Click(object sender, EventArgs e)
        {
            await progressBar1.DoProgress(2000);
            Trace.WriteLine("Done");          
            MessageBox.Show("Done");
        }
    
        private void buttonMoveButton1_Click(object sender, EventArgs e)
        {
            //to prove UI click several times buttonMove while the task is ruunning
            buttonStart.Top += 10;
        }
    }
    public static class WaitExtensions
    {
        public static async Task DoProgress(this ProgressBar progressBar, int sleepTimeMiliseconds)
        {
            int sleepInterval = 50;
            int progressSteps = sleepTimeMiliseconds / sleepInterval; //every 50ms feedback
            progressBar.Maximum = progressSteps;
            SynchronizationContext synchronizationContext = SynchronizationContext.Current;
            await Task.Run(() =>
            {
                synchronizationContext.OperationStarted();
                for (int i = 0; i <= progressSteps; i++)
                {
                    Thread.Sleep(sleepInterval);
                    synchronizationContext.Post(new SendOrPostCallback(o =>
                    {
                        Trace.WriteLine((int)o + "%");
                        progressBar.Value = (int)o;
                    }), i);
                }
                synchronizationContext.OperationCompleted();
            });
        }
    }    
        
