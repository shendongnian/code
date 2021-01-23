    using(var ctx = new StradaDataReviewContext2())
    {
       foreach(var value in values)
       {
           value.Username = user;
           value.Changed = DateTime.Now;
           ctx.UOSChangeLog.Add(value);
       }
       ctx.SaveChanges();
       return true;
    }
