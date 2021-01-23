    // in UserMoney.cs
    [Timestamp]
    public byte[] RowVersion { get; set; }
    // in model builder
    modelBuilder.Entity<UserMoney>().Property(p => p.RowVersion).IsConcurrencyToken();
    // The update logic
    public bool Buy(int moneyToSpend, byte[] rowVersion)
    {
        try
        {
            var moneyRow = db.UserMoney.Find(loggedinUserID);
            if(moneyRow.MONEY < moneyToSpend)
            {            
                return false;
            }
            //code for placing order
            moneyRow.MONEY -= moneyToSpend;
            return true;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            var entry = ex.Entries.Single();
            var submittedUserMoney = (UserMoney) entry.Entity;
            var databaseValue = entry.GetDatabaseValues();
            if (databaseValue == null)
            {
                // this entry is no longer existed in db
            }
            else
            {
                // this entry is existed and have newer version in db
                var userMoneyInDb = (UserMoney) databaseValue.ToObject();
            }
        }
        catch (RetryLimitExceededException)
        {
            // probably put some logs here
        }
    }
