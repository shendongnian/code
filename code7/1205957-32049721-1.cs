    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, Namespace = Namespaces.Example)]
    public class Example: IExample
    {
    
        public string ExampleRequests()
        {
        ...
        MyHeader soapHeader = SoapHeaderHelper<MyHeader>.GetInputHeader("MyHeader");
        if (soapHeader == null || soapHeader.Username.IsNullOrEmpty() || !ValidateCredentials(soapHeader))
        {
        return "You do not have permission to access this service";
        }
        ...
        }
        
        private bool ValidateCredentials(MyHeader soapHeader)
        {
        if (soapHeader.Username == "admin" && soapHeader.Password == "123")
        {
        return true; 
        }
        return false;
        }
    
    }
