    public interface INamed{
        string Name{get;}
    }
    
    public class Person : INamed{
        public string Name{get;set;}
    }
    
    public class Place : INamed{
        public string Name{get;set;}
    }
    
    public class Thing : INamed{
        public string Name{get;set;}
    }
