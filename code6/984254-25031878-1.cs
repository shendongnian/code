    public static void DoSomething(ISomePropEntity table)
    {
        using (var db = new LiCPS_Entities())
        {
            var temp = db.Database.SqlQuery<table>("SELECT * FROM " + table.Name).ToList();
            if (temp.Any())
            {
                foreach (var obj in temp)
                {
                   table.setSomeProp(...);
                }
                db.SaveChanges();
            }
        }
    }
