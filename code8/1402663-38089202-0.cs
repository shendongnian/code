    public partial class ficharioEntities : DbContext
    {
         public ficharioEntities(string password)
                            :base(GetEntityConnectionString(password))
         {
         }
         private static string GetEntityConnectionString(string password){
              string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["fichario"].ConnectionString;
              System.Data.EntityClient.EntityConnectionStringBuilder entityconnection = new System.Data.EntityClient.EntityConnectionStringBuilder(s);
           //EntityConnectionStringBuilder inherits from DBConnectionStringBuilder 
          //so you should be able to replace the password simply
          entityconnection["Password"] = password;
     
         //otherwise, if you know the connection properties you need
        //you could rebuild an entity connection object.
            return entityconnection.ToString();
         }
    }
