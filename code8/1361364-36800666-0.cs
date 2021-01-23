    // Define a weakly typed interface, to be called
    // by the invoking code.
    public interface IRequestHandler
    {
      public string HandleRequest(string xmlRequest);
    }
    // Defines a generic handler, accepting two type parameters, one
    // for the request, one for the response.
    public abstract class RequestHandler<RequestType, ResponseType> : IRequestHandler
    {
      
      public XmlSerializer GetRequestSerializer()
      {
        return GetSerializer(typeof(RequestType));
      }
      
      public XmlSerializer GetResponseSerializer()
      {
        return GetSerializer(typeof(ResponseType));
        // an alternative, depending upon your deserialization library,
        // could be:
        // return GetSerializer<ResponseType>();
      }
      
      public XmlSerializer GetSerializer(Type dataType)
      {
        ... resolve based on type.
      }
      
      public string HandleRequest(string xmlRequest)
      {
        if (request == null) throw new ArgumentNullException("request");
        
        var requestSerializer = GetRequestSerializer();
        var typedRequest = requestSerializer.Deserialize(xmlRequest) as RequestType;
        // response is a ResponseType
        var response = ProcessRequest(typedRequest);
        
        var responseSerializer = GetResponseSerializer();
        
        return responseSerializer.Serialize(response);
      }
      
      protected abstract ResponseType ProcessRequest(RequestType request);
    }
    // One handler implementation
    // you can just declare the class and RequestHandler inheritance,
    // and then right click and ask Visual Studio to "Implement abstract members"
    public class ActualRequestHandler : RequestHandler<ActualRequest, ActualResponse>
    {
      protected ActualResponse ProcessRequest(ActualRequest request)
      {
        // ... do your processing
      }
    }
    // One handler implementation
    public class AnotherRequestHandler : RequestHandler<AnotherRequest, AnotherResponse>
    {
      protected AnotherResponse ProcessRequest(AnotherRequest request)
      {
        // ... do your processing
      }
    }
