    public class ContactType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
    
    public class RootObject
    {
        public List<ContactType> Result { get; set; }
    }
