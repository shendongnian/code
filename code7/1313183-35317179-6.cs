    public class Library
    {
        public string name { get; set; }
    }
    
    public class JSON
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public string CreatedDate { get; set; }
        public List<Library> libraries { get; set; }
    }
