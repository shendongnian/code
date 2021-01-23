    public Interface IProduct
    {
        string Category {get;set;}
        string Name {get;set;}
    }
    
    public class Laptop : IProduct
    {
        public string Category {get;set;}
        public string Name {get;set;}
        public bool HasBluRay {get;set;}
    }
    
    public class Mobile :IProduct
    {
        public string Category {get;set;}
        public string Name {get;set;}
        public bool externalRAMSlot {get;set;}
    }
