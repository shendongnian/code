    public class Note
    {
        public decimal NoteId { get; set; } 
        public string AccountId { get; set; }
        public string NoteValue { get; set; }
    
        //FK property
        public int ClientId{get;set;}
    
        public virtual Client Client { get; set; }
    }
