        private bool TestConnEF()
        {
            using (var db = new DbContext())
            {
                try
                {
                    db.Database.Connection.Open();
                    if (db.Database.Connection.State == ConnectionState.Open)
                    {
                       return true;
                    }
                    return false;
                }
                catch(Exception ex)
                {
                    return false
                }
            }
        }
