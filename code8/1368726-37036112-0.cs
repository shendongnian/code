    public class RootObject
    {
        public InterfaceObject iObject { get; set; }
    }
    public class InterfaceObject 
    {
        public string hash { get; set; }
        public Attribute attribute { get; set; }
    }
    public class Attribute
    {
        public string hash { get; set; }
        public string role { get; set; }
        public string status { get; set; }
        public string cost { get; set; }
        public string priorityNo { get; set; }
        public string type { get; set; }
    }    
