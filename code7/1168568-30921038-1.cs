    public class Element
    {
        public string Name { get; set; }
        public MyObject MyObject1 { get; set; }
        public MyObject MyObject2 { get; set; }
    }
    public class MyObject
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
