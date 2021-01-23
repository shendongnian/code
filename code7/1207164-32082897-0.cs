        BackgroundWorker workerOne = new BackgroundWorker();
        BackgroundWorker workerTwo = new BackgroundWorker();
        private void MyForm_Load(object sender, EventArgs e)
        {
            workerOne.DoWork += workerOne_DoWork;
            workerTwo.DoWork += workerTwo_DoWork;
        }
        private void ThingOne_Click(object sender, EventArgs e)
        {
            workerOne.RunWorkerAsync();
        }
        private void ThingOne_Click(object sender, EventArgs e)
        {
            workerTwo.RunWorkerAsync();
        }
        void workerOne_DoWork(object sender, DoWorkEventArgs e)
        {
            //This will run as async and not interupt main thread
        }
        void workerTwo_DoWork(object sender, DoWorkEventArgs e)
        {
            //This will run as async and not interupt main thread
        }
