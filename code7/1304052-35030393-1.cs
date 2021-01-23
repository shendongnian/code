    [XmlRoot(Namespace = "", ElementName = "param ")]
    public class Param 
    {
        public List<professor> Professor { get; set; }
        public List<course> Course { get; set; }
    }
    public class professor
    {
        public int id;
        public string name;
    
        public professor() { }
    }
    public class course
    {
        public int id;
        public string name;
        public course() { }
    }
