    public class Note
        {
            public Note()
            {
                NoteTags = new HashSet<NoteTag>();
            }
    
            public int NoteId { get; set; }
            public virtual ICollection<NoteTag> NoteTags { get; set; }
            [...]
        }
