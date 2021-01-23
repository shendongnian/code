    using (TransactionScope scope = new TransactionScope())
    {
        using (Schema1Entities db1 = new Schema1Entities())
        using (Schema2Entities db2 = new Schema2Entities())
        {
            db1.SaveChanges();
            db2.SaveChanges();
        }
        scope.Complete();
    }
