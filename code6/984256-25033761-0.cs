    public static void DoSomething<TTable>() where TTable : class
        {
            using (var db = new Entities())
            {
                var temp = db.Database.SqlQuery<TTable>("SELECT SomeProp FROM " + typeof(TTable).Name).ToList();
                if (temp.Any())
                {
                    foreach (var obj in temp)
                    {
                        ((dynamic)obj).SomeProp = 1;
                        db.Entry(obj).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
        }
