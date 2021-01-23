    public class Note
    {
        public int NoteID { get; set; }
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public DateTime Timestamp { get; set; }
        public string Tags { get; set; }
        public virtual Project Project {set;get;}
    }
