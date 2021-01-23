     public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
     {
          GlobalVariables.worker = sender as BackgroundWorker;
          try
          {
            if (GlobalVariables.worker.CancellationPending == true)
            {
                 e.Cancel = true;
                 return;
            }
            else
            {
                Object callResponse = CallServer(ServerName, ActionName);
                if (GlobalVariables.worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                 }
                 else
                 {
                     e.Result = callResponse;
                 }
                           
              }
             }
             catch (Exception ee)
             {
                 e.Cancel = true;
                 if (ee.GetType().IsAssignableFrom(typeof(System.ServiceModel.CommunicationObjectAbortedException)))
                 {
                    MessageBox.Show("The Request Was Cancelled");
                 }
                 else
                 {
                    GlobalFunctions.ShowError(ee);
                 }
                        
              }
      }
    
    public void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Cancelled)
        {}
        else
        {
        //continue
        }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
       if (GlobalVariables.worker.IsBusy == true)
       {
    
           server.abort(); //service reference
           GlobalVariables.worker.CancelAsync();
            GlobalVariables.worker.Dispose();
        }
    }
