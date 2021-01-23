    public class Foo 
    {
      // initialize: best practice
      private List<CacheRequest> _pendingRequests =
        new List<CacheRequest>();
 
      // upper case: best practice
      public void AddRequest(int sequence, Request request)
      {
        if (request.Response == null)
        {
          throw new ArgumentException("Request Response cannot be null.");
        }
        _pendingRequests.Add(new CacheRequest()
        {
          Sequence = sequence,
          Request = request,
          ResponseType = request.Response.GetType()
        });
      }
      public bool TryGetRequest<T>(int seq, out Request request, out T response)
        where T : Request
      {
        response = null;
		request = null;
        var pendingRequest = _pendingRequests
          .Where(cr => cr.ResponseType == typeof(T))
          .FirstOrDefault(r => r.Sequence  == seq);
        var result = pendingRequest != null;
        if (result)
		{
			request = pendingRequest.Request;
			response = request.Response as T;
		}
        return result;
      }
      private class CacheRequest
      {
        public int Sequence { get; set; }
        public Request Request { get; set; }
        public Type ResponseType { get; set; }
      }
    }
    public class Request
    {
     public Response Response { get; set; }
    }
    public abstract class Response { }
    public class HttpResponse : Response { }
    public class UdpResponse : Response { }
