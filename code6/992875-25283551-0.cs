    public void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker ;
        for (int i = 0; i < countPlages; i++)
        {
             if ((worker.CancellationPending == true)) 
             {
                 e.Cancel = true;
                 break;
             }
             #do something else
        }
}
