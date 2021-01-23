    public class MyRequest
    {
        public string Name { get; set ;}
        public string Country { get; set ;}
        public string Twitter { get; set ;}
    }
    public object Any(MyRequest request)
    {           
        return request;
    }
