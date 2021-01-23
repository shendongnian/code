    public class SomeType
    {
        public string Name {get;set;}
        public int Age {get;set;}
    }
    
    class ApiReply
    {
        int success {get;set}
        List<SomeType> value {get;set;}
        int status {get;set;}
        string reason {get;set;}
    }
