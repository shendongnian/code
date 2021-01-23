    public class Note
        {
            public Note()
            {
                NoteTags = new HashSet<NoteTag>();
            }
            //primary key
            public int NoteId { get; set; }
            public virtual ICollection<NoteTag> NoteTags { get; set; }
            [...]
        }
