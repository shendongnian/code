    public class Lead
    {
        public Lead()
        {
            Documents = new List<Document>();
        }
        public string LeadFirstName { get; set; }
        public List<Document> Documents { get; private set; }
    }
