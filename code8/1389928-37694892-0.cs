    public class BGWQue
    {
        public BackgroundWorker Worker_1 { get; set; }
        public BackgroundWorker Worker_2 { get; set; }
        bool endWorkerLoop = false;
        public BGWQue()
        {
            this.Worker_1 = new BackgroundWorker();
            this.Worker_1.DoWork += Worker_1_DoWork;
            this.Worker_1.RunWorkerCompleted += Worker_1_RunWorkerCompleted;
            this.Worker_2 = new BackgroundWorker();
            this.Worker_2.DoWork += Worker_2_DoWork;
            this.Worker_2.RunWorkerCompleted += Worker_2_RunWorkerCompleted;
        }
        void Worker_1_DoWork(object sender, DoWorkEventArgs e)
        {
            job_1();
        }
        void Worker_1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // condition to end the cycle
            if (!endWorkerLoop)
            {
                this.Worker_2.RunWorkerAsync();
            }
            
        }
        void Worker_2_DoWork(object sender, DoWorkEventArgs e)
        {
            job_2();
        }
        void Worker_2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // condition to end the cycle
            if (!endWorkerLoop)
            {
                this.Worker_1.RunWorkerAsync();
            }
        }
        public void startWorkers()
        {
            this.Worker_1.RunWorkerAsync();
        }
        // fictional jobs for the workers
        public void job_1()
        {
            Thread.Sleep(2000);
        }
        public void job_2()
        {
            Thread.Sleep(3000);
        }
    }
