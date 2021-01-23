    public long ChangeScoreAmount(int userID, long amount)
    {
        using(var ts = new TransactionScope(TransactionScopeOption.RequiresNew, 
            new TransactionOptions { IsolationLevel = IsolationLevel.RepeatableRead })
        {
          var profile = this.Entities.account_profile.First(q => q.AccountID == userID);
    
          profile.Score += amount;
    
          this.Entities.SaveChanges();
    
          ts.Complete();
    
          return profile.Score;
        }    
    }
