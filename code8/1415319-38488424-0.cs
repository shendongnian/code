            using (DataBASE db = new DataBASE())
            {
                try
                {
                    db.Database.ExecuteSqlCommand("INSERT INTO Users VALUES({0},{1})", Int32.Parse(values[0]), Boolean.Parse(values[1]));
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    var exception = e;
                }
            }
