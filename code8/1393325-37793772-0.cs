            using (var t = ((DbContext)MyDb).Database.BeginTransaction())
            {
                try
                {
                    MyDb.SaveChanges();
                    t.Commit();//Break point here
                }
                catch
                {
                    t.Rollback();
                }
            }
