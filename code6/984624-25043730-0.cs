    public class Original
    {
        public int ID { get; set; }
        public string Name { get; private set; }
        public virtual Traduction Traduction { get; private set; }
    }
    public class Traduction
    { 
        public int ID { get; set; }
        public virtual Original Original { get; private set; }
        public string Content { get; private set; }
    }
