    public class ValueAdd
    {
        public string description { get; set; }
    }
    
    public class ValueAdds
    {
        public int size { get; set; }
        public List<ValueAdd> ValueAdd { get; set; }
    }
    
    public class RootObject
    {
        public ValueAdds ValueAdds { get; set; }
    }
