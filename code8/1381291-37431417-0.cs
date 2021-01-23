    public sealed class ClassA
    {
        
        public string Name { get; set; }
        public string Detail { get; set; }
        public List<string> Comments { get; set; }
        public Issue()
        {
            Comments = new List<string>();
        }
    }
