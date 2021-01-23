    public class Subject
    {
        public int Id { get; set; }
        public string OEPTitle { get; set; }
    }
    
    public class RootObject
    {
        public int Class { get; set; }
        public string ClassUrl { get; set; }
        public string OEPTitle { get; set; }
        public List<Subject> Subject { get; set; }
        public bool IsArchived { get; set; }
    }
