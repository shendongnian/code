    public void Put(string accNum, decimal amount, MyDbContext context)
    {
        var query = from t in context.MoneyTransactions
                    where t.AccountNumber.Equals(accNum)
                    select t;
        MoneyTransaction mt = query.First();
        mt.Amount += amount;
        db.SaveChanges();
    }
    
    public void Put(string accNum, decimal amount)
    {
        using (var db = new MyDbContext())
        {
            Put(accNum, amount, db);   
        }
    }
