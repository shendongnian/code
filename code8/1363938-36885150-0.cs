    public class Publisher
    {
        public string name { get; set; }
        public string role { get; set; }
        public string emailAddress { get; set; }
    }
    
    public class Editorship
    {
        public string title { get; set; }
        public string editorial_role { get; set; }
        public int date_start { get; set; }
        public int date_end { get; set; }
        public Publisher publisher { get; set; }
    }
    
    public class Jci
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public string Institution { get; set; }
        public List<string> Fields_of_interest { get; set; }
        public string emailAddress { get; set; }
        public List<Editorship> editorship { get; set; }
    }
    
    public class Editorship2
    {
        public string title { get; set; }
        public string editorial_role { get; set; }
        public int publication_year { get; set; }
    }
    
    public class Sid
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Title { get; set; }
        public string primary_organisation { get; set; }
        public string emailAddress { get; set; }
        public List<Editorship2> editorship { get; set; }
    }
    
    public class Properties
    {
        public List<Jci> jci { get; set; }
        public List<Sid> sid { get; set; }
    }
    
    public class RootObject
    {
        public Properties properties { get; set; }
    }
