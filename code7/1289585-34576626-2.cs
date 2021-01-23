    public class Tag
    {
        public Tag()
        {
            NoteTags = new HashSet<NoteTag>();
        }
    
        public int TagId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<NoteTag> NoteTags { get; set; }
    }
