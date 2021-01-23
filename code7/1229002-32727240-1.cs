    public class Response
    {
       public int Status { get; set; }
       public string Message { get; set; }
    }
    public interface IPayloadHolder
    {
        public object Payload { get; }
    }
    
    public class Response<T> : Response, IPayloadHolder
    {
       public T Payload { get; set; }
       // By using explicit interface implementation, this
       // doesn't get in the way for normal usage.
       IPayloadHolder.Payload { get { return Payload; } }
    }
