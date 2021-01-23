    While(RecordsToProcess.Count() > 0)
    {
      System.Threading.Thread.Sleep(1000);
      RecordsToProcess = MyTable.Where(i => i.Processed == 0);
    }
