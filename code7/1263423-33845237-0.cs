        namespace RandomLoader
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            bw.RunWorkerAsync();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bw.WorkerReportsProgress = true;
            //The button was already made non-visible in my form's property window
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            this.Text = e.ProgressPercentage.ToString() + " %"; // to make the form change name to the current progress of the Progress bar (I didnt want to make the text on top of the progress bar)
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(#); // to make the progress bar look realistic, so it had tiny stops and stuttering, like an actually functioning download bar does.wasnt instantly at 100% (I used 100 as in 1/10th of a second stutters before the bw would update the bar)
                bw.ReportProgress(i); // report progress from the background worker
            }
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) // Once my bar is done loading I want it to sleep for just a tiny bit, because the background worker is done before the visualization on the progressbar is done.
        {
            Thread.Sleep(#);
            button1.Visible = true;
			this.Text = "Done Loading"; //Instead of making a convertion from string to int in my ProgressChanged event, I simply made it so that once it was done, it would say "done loading" rather than the current %
        }
        private void button1_Click(object sender, EventArgs e) // As this was a loader for my next few programs, I want it to open my not yet finished program, so an empty form will suffice as an example.
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
