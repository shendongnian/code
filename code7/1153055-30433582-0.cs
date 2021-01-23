    public class Contact
        {
            public bool isConnection { get; set; }
            public int id { get; set; }
            public List<Field> fields { get; set; }
        }
    public class Field
    {
        public int id { get; set; }
        public string type { get; set; }
        public object value { get; set; }
        public string editedBy { get; set; }
        public string[] flags { get; set; }
        public string[] categories { get; set; }
        public DateTime updated { get; set; }
        public DateTime created { get; set; }
    }
    public class Name
    {
        public string givenName { get; set; }
        public string middleName { get; set; }
        public string familyName { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set; }
        public string givenNameSound { get; set; }
        public string familyNameSound { get; set; }
    }
