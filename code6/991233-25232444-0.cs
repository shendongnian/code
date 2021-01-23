    public class MyRepostory : IRepository
    {
         public IEnumerable<Foo> GetFoos()
         {
              using (var connection = new SqlConnection(connectionString))
              {
                  connection.Open();
                  // ... get the data, etc. ...
                  return foos;
              }
         }
    }
