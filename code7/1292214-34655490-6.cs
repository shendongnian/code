    public bool AccountIsGood(IQueryable<Transaction> dbTransactions)
    {
        var transactions = dbTransactions.OrderBy(t => t.Date);
       // transactions is now and OrderedQueryable
        var sum = 0M;
        var totalTrans = transactions.Count();
        var skip = 0;
        while(skip < totalTrans)
        {
           foreach(var tran in transactions.Skip(skip).Take(100).ToList())
           {
          
              if(tran.Type = TransactionType.D)
              {
                 sum -= tran.Value;
              }
              else
              {
                 sum += tran.Value;
              }
          
              if(sum > 1000M)
              {
                return true;
             }
           }
         }
         skip += 100;
       }
     return false;
    }
