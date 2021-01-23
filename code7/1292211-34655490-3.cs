    public bool AccountIsGood(IEnumerable<Transaction> dbTransactions)
    {
        var transactions = dbTransactions.OrderBy(t => t.Date).ToList();
        var sum = 0;
        foreach(var tran in transactions)
        {
          
           if(tran.Type = TransactionType.D)
           {
              return false;
           }
           sum += tran.Value;
           if(sum > 1000)
           {
             return true;
           }
       }
      return false;
    }
