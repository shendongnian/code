    SqlTransaction Transaction = null;
    try
    {
        using(SqlConnection conn = new SqlConnection(MS_SQL.ConnectionContext.ConnectionString))
        using(Server server = new Server(new ServerConnection(conn)))
        {
           conn.Open();
           using(Transaction = Connection.BeginTransaction())
           {
               string[] Scripts = System.IO.Directory.GetFiles(ScriptsLocation);
               for (int i = 0; i < Scripts.Length; i++)
                  server.ConnectionContext.ExecuteNonQuery(Scripts[i]);
           }
           Transaction.Commit();
        }
    }
    catch(Exception ex)
    {
        // Display error and rollback
        Transaction.Rollback();
    }
