     public class DataService : IDataService
     {
          private readonly IJavaScriptSerializer  _serializer;
          public DataService(IJavaScriptSerializer serializer)
          {
              _serializer = serializer;
          }
     }
