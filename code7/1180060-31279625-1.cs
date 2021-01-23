    <!-- language: c# -->
        string connectionString = "Context Connection = true;"; // default = SQLCLR connection
        if (!SqlContext.IsAvailable) // if not running within SQL Server, get from config file
        {
          connectionString = 
                    ConfigurationManager.ConnectionStrings["CoolioAppDB"].ConnectionString;
        }
