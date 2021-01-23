    using (ScotiaNYAEntities context = new ScotiaNYAEntities())  
    {
      foreach (string line in File.ReadLines(pathToFile))
      {
        if (line.Contains("AMOUNT:"))
        {
          if (IsAmount)
          {
            string amount = line.Replace("AMOUNT:", string.Empty).Trim();
            
            TTransaction txn = new TTransaction();
            
            txn.Amount = amount;
            txn.TRN = "sdfgsdfg";
            
            context.TTransactions.Add(txn);
          }
        }
      }
      
      context.SaveChanges();
    }
