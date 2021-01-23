    ThreadPool.QueueUserWorkItem(new WaitCallback(myFunction), xp);
----------
    public void myFunction(object state)
    {
      int xp = (int)state;
      
      myLabel.Invoke((MethodInvoker)(() => myLabel.SelectedText = xp)); //Thread Safe Label Updater
      new System.Threading.ManualResetEvent(false).WaitOne(2000); //Wait 2 Seconds
      myLabel.Invoke((MethodInvoker)(() => myLabel.SelectedText = string.Empty)); //Sets the label to empty. Could also be used to put back to totalXP
    }
