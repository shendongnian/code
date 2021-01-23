    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Create a fake list for testing.
        string[] GenerateList() 
        {
            return new string[500];
        }
        void DoWork(IProgress<int> taskProgress)
        {
            // Sleep the thread just so we can test and ensure we are reporting progress.
            Thread.Sleep(50);
            // We're done doing our work, report that the UI can increment its progress by 1.
            taskProgress.Report(1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var list = GenerateList();
            progressBar1.Maximum = list.Length;
            // Setup the progress so that it increments the progress bar.
            var listProgress = new Progress<int>(progressAmount => this.progressBar1.Value += progressAmount);
            Task.Run(() => Parallel.ForEach(list, item =>
            {
                // Pass the IProgress<T> in to the method, so it may report when it is completed.
                DoWork(listProgress);
            }));
        }
    }
