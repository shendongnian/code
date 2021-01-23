    void Main() {
        Response<MyResponse> myResponse = new Response<MyResponse>(new List<MyResponse>(), null, null);
        var serializer = new JsonSerializer();
        StringBuilder sb = new StringBuilder();
        
        using(var writer = new StringWriter(sb)) {
            using (var jWriter = new JsonTextWriter(writer)) {
                serializer.NullValueHandling = NullValueHandling.Ignore;
                serializer.Serialize(jWriter, myResponse);
            }
        }
        
        Console.WriteLine(sb.ToString());
    }
    
    public interface IResponse<T> {
      IList<Error> Errors { get; }
      IPaging Paging { get; }
      IList<T> Result { get; }    
    }
    
    public class Response<T> : IResponse<T> {
    
      public IList<Error> Errors { get; private set; }
      public IPaging Paging { get; private set; }
      public IList<T> Result { get; private set; }
    
      public Response(IList<T> result, IPaging paging, IList<Error> errors) {
        Errors = errors;
        Paging = paging;
        Result = result;
      }
    
    }
    
    public class Error {
    
    
    }
    
    public interface IPaging {
    
    }
    
    public class MyResponse {
        public string Name {get; set;}
    }
