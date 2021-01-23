    private void worker_DoWork(object sender, DoWorkEventArgs e)
    {
         List<string> genericlist = e.Argument as List<string>;//cast
          for (int i = 0; i < genericlist.Count; i++) {
               Console.WriteLine(genericlist[i]);
               Thread.Sleep(5000);
           }
    }
