    public class Extension
    {
        public const Extension TXT = new Extension(".txt");
        public const Extension XML = new Extension(".xml");
        public Value{get;private set;}
        public Extension(string value){Value = value;}
     }
