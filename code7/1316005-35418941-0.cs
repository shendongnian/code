    using (var conn = new System.Data.SqlClient.SqlConnection("yourConnectionString"))
    {
        conn.Open();
        using (var trans = conn.BeginTransaction())
        {
            try
            {
                using (var dbc1 = new System.Data.Entity.DbContext(conn, contextOwnsConnection: false))
                {
                    dbc1.Database.UseTransaction(trans);
                    // do some work
                    // ...
                    dbc1.SaveChanges();
                }
    
                using (var dbc2 = new System.Data.Entity.DbContext(conn, contextOwnsConnection: false))
                {
                    dbc2.Database.UseTransaction(trans);
                    // do some work
                    // ...
                    dbc2.SaveChanges();
                }
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
            }
        }
    }
