    class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader("json.json");
            var jsonText = sr.ReadToEnd();
            Documents myDocuments = JsonConvert.DeserializeObject<Documents>(jsonText);
        }
    }
    public class group_items
    {
        public string code { get; set; }
        public string description { get; set; }
    }
    public class type_items
    {
        public string code { get; set; }
        public string description { get; set; }
    }
    public class metadata_list
    {
    }
    public class doc_items
    {
        public int id { get; set; }
        public group_items GroupItems { get; set; }
        public type_items TypeItems { get; set; }
        public string reference { get; set; }
        public string date { get; set; }
        public string description { get; set; }
        public string notes { get; set; }
        public string lastUpdateDate { get; set; }
        public string location { get; set; }
        public metadata_list MetadataList { get; set; }
    }
    public class Documents
    {
        public int totalItems { get; set; }
        public List<doc_items> items { get; set; }
    }
