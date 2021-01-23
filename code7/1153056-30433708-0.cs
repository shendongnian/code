        public class Field
        {
            public int id { get; set; }
            public string type { get; set; }
            public object value { get; set; }
            public string editedBy { get; set; }
            public List<object> flags { get; set; }
            public List<object> categories { get; set; }
            public string updated { get; set; }
            public string created { get; set; }
        }
    
        public class Contact
        {
            public bool isConnection { get; set; }
            public int id { get; set; }
            public List<Field> fields { get; set; }
        }
    
        public class Contacts
        {
            public List<Contact> contact { get; set; }
        }
    
        public class RootObject
        {
            public Contacts contacts { get; set; }
        }
