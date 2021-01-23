    public class Status
    {
       public string messageType { get; set; }
       public string message { get; set; }
    }
    public class ServiceContextType
    {
       public Status status { get; set; }
    }
    public class CreateCustomerResponse
    {
        public ServiceContextType serviceContextType { get; set; }
    }
    public class RootObject
    {
       public CreateCustomerResponse createCustomerResponse { get; set; }
    }
