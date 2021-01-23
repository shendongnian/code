    public class ValueAdd
    {
        public string description { get; set; }
    }
    
    public class ValueAdds
    {
        public string size { get; set; }
        public ValueAdd ValueAdd { get; set; }
    }
    
    public class RootObject
    {
        public ValueAdds ValueAdds { get; set; }
    }
