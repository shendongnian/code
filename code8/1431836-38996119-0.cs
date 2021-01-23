    public class CustomerResponse
    {
    public string CreateCustomerResponse {get;set;}
    public CustomContext ServiceContextType {get;set;}
    }
    public class CustomContext 
    {
    public CustomStatus Status{get;set;}
    }
    public class CustomStatus 
    {
    public string Message{get;set;}
    public string MessageType{get;set;}
    }
 
 
