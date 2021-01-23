    string connectionString
          = "Data Source=(LocalDB)\\v11.0;AttachDbFilename="
          + fileSpec + ";database=EventsListDB";
  
    /* We can't go straight into the context and create the DB because 
     * it needs a connection to "master" and can't create it. Although this
     * looks completely unrelated, under the hood it leaves behind something
     * that EF can pick up and use- and it can't hurt to delete any references 
     * to databases of the same name that may be lurking in other previously
     * used directories.
     */
  
    SqlConnectionStringBuilder masterCSB = new SqlConnectionStringBuilder(connectionString);
    masterCSB.InitialCatalog = "master";
    masterCSB.AttachDBFilename = "";
  
    using (var sqlConn = new SqlConnection(masterCSB.ToString()))
    {
        sqlConn.Open();
        using (var cmd = sqlConn.CreateCommand())
        {
            bool done = false;
            int attempt = 0;
            do
            {
                try
                {
                    cmd.CommandText =
                        String.Format(
                            "IF EXISTS (Select name from sys.databases " + 
                            "WHERE name = '{0}') " +
                            "DROP DATABASE {0}", "EventsListDB");
                    cmd.ExecuteNonQuery();
                    done = true;
                }
                catch (System.Exception ex)
                {
                    /* We sometimes get odd exceptions that're probably because LocalDB hasn't finished starting. */
                    if (attempt++ > 5)
                    {
                        throw ex;
                    }
                    else Thread.Sleep(100);
  
                }
            } while (!done);
        }
    }
  
    /* Now we can create the context and use that to create the DB. Note that
     * a custom constructor's been added to the context exposing the base
     * constructor that can take a connection string- changing the connection
     * string after the default constructor reads it from App.config isn't 
     * sufficient.
     */
    EventsListDBEntities ctx = new EventsListDBEntities(connectionString);
    ctx.Database.Create();
    int numRecords = ctx.EventLists.Count(); //See if it really worked.
