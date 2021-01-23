    static void Main()
    {
        string constr = //Connection string         
        DbProviderFactory factory = DbProviderFactories.GetFactory("Oracle.DataAccess.Client");     
        DbConnection conn = factory.CreateConnection();
     
        try
        {
          conn.ConnectionString = constr;
          conn.Open(); 
          DbCommand cmd = factory.CreateCommand();
          cmd.Connection = conn;
          cmd.CommandText = "ALTER USER xxxxx ACCOUNT UNLOCK;"; 
          cmd.ExecuteNonQuery().
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          Console.WriteLine(ex.StackTrace);
        }
    }
