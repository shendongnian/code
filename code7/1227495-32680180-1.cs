    public class SomeServiceNeedingDatabaseConnection
    {
         private readonly IConnectionFactory connectionFactory;
    
         public SomeServiceNeedingDatabaseConnection(IConnectionFactory connectionFactory)
         {
              this.connectionFactory = connectionFactory;
         }
    
         public void SomeMethodNeedingDatabase()
         {
              using (var connection = this.connectionFactory.GetNewConnection())
              {
                     // Do something with connection
              }
         }
    }
