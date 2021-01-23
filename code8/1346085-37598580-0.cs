    #r "System.Data"
    using System;
    using System.Data.SqlClient;
    public static async Task Run(TimerInfo myTimer, TraceWriter log)
    {
    
        string userName = "*******";
        string passWord = "********";
        var connectionString = $"Server=tcp:work-on-  sqlazure.database.windows.net,1433;Data Source=work-on-sqlazure.database.windows.net;Initial Catalog=VideoStore;Persist Security Info=False;User ID={userName};Password={passWord};Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    
        using(SqlConnection cns = new SqlConnection(connectionString))
        {
             cns.Open();
             var truncateUserTable = "DELETE FROM Video";
         
             using(SqlCommand cmd = new SqlCommand(truncateUserTable, cns))
             {
                 int rowsDeleted = await cmd.ExecuteNonQueryAsync();
             }
        }
    }
