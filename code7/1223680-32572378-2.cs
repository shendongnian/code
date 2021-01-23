    public interface IApiRequestHandler {
        // type of request which is handled by this handler
        Type RequestType { get; }
        void Validate(BaseApiRequest request);
        void Process(BaseApiRequest request);
    }
    
    // specific request
    public class SomeDataRequest : BaseApiRequest<int> {
        public string Argument1 { get; set; }
        public long Argument2 { get; set; }
    }
    
    // specific request handler
    public class SomeDataRequestHandler : IApiRequestHandler {
        public Type RequestType { get { return typeof(SomeDataRequest); } }
        public void Validate(BaseApiRequest baseRequest) {
            // safe to cast here
            var request = (SomeDataRequest) baseRequest;
            // validate and throw exception if something is wrong
            // no reason to validate when we already started processing
        }
        public void Process(BaseApiRequest baseRequest) {
            // safe to cast here
            var request = (SomeDataRequest) baseRequest;
            // do processing
            request.SetResult(1);
        }
    }
