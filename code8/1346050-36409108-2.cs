    public class Event
    {
        public Event() {
            Documents = new List<Document>();
        }
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public DateTime? EventDate { get; set; }
        public bool EventBool { get; set; }        
        public IList<Document> Documents { get; set; }
        public Document Document { get; set; }        
    }
    public class Document {
        public int DocumentID { get; set; }
        public string DocumentTitle { get; set; }
    }
