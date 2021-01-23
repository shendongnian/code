    private string hellow="hello";        
    private void button1_Click(object sender, EventArgs e)
    {
        bool createAndRunWorkResult = CreateAndRunWork();       
    }
    private bool CreateAndRunWork()
    {
        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += worker_DoWork;
        worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        worker.RunWorkerAsync();
        return true;
    }
    private void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        //Nothing here;
    }
    private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        hellow="aloha";
            //Do something that need wait RunBackGroundWorkerCompleted execute here.
            //MessageBox.Show(hellow);
    }
