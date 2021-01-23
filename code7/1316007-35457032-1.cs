    using (var db1 = new DbContext1())
    {
        using (var trans = db1.Database.BeginTransaction())
        {
            try
            {
                //do the insertion into db1
                db1.SaveChanges();
                using (var db2 = new DbContext2())
                {
                    //do the insertions into db2
                    db2.SaveChanges();
                }
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();  
            }
        }
    }
