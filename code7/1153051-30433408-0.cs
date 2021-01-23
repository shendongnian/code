    public class Field
    {
        public int id { get; set; }
        public string type { get; set; }
        public object value { get; set; }
        public string editedBy { get; set; }
        public IList<object> flags { get; set; }
        public IList<object> categories { get; set; }
        public DateTime updated { get; set; }
        public DateTime created { get; set; }
    }
    public class Contact
    {
        public bool isConnection { get; set; }
        public int id { get; set; }
        public IList<Field> fields { get; set; }
    }
    public class Contacts
    {
        public IList<Contact> contact { get; set; }
    }
    public class Example
    {
        public Contacts contacts { get; set; }
    }
