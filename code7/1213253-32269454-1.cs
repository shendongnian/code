    static void Main()
    {
        string constr = //Connection string         
        DbProviderFactory factory = DbProviderFactories.GetFactory("Oracle.DataAccess.Client");     
             
        try
        {
          using(DbConnection conn = factory.CreateConnection())
          {
              conn.ConnectionString = constr;
              conn.Open(); 
              using(DbCommand cmd = conn.CreateCommand())
              {
                 cmd.CommandText = "ALTER USER xxxxx ACCOUNT UNLOCK;"; 
                 cmd.ExecuteNonQuery();
              }
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          Console.WriteLine(ex.StackTrace);
        }
    }
