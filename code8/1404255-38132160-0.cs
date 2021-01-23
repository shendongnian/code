    static void Main()
    {
        SqlConnection myConnection = 
           new SqlConnection(
                "server=myamazonserver.eu-central-1.rds.amazonaws.com;user id=rootusername;password=mypassword;database=mydatabasename; Convert Zero DateTime=True; Allow User Variables=True" providerName="MySql.Data.MySqlClient"
              );
        try
        {
            myConnection.Open();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
