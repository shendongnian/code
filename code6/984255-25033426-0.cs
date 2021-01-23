    public static void DoSomething<TTable>(string table) where TTable : class
    {
        using (var db = new Entities())
        {
            var temp = db.Database.SqlQuery<TTable>("SELECT * FROM " + table).ToList();
            if (temp.Any())
            {
                foreach (var obj in temp)
                {
                    ((dynamic)obj).SomeProp= 1;
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
    }
