    public interface IService<RequestObject>
    {
       //put method and property signatures of Service<RequestObject> here
    }
    
    public class ServiceObject:Service<RequestObject>, IService<RequestObject>
    {
       public ServiceObject(RequestObject request): base(request){
            //or however the Service<Request> object is instantiated.
       };
    }
