    public interface INote
    {
        int NoteId { get; set; }
        ICollection<INoteTag> NoteTags { get; set; }
    }
    
    public interface INoteTag
    {
        int NoteTagId { get; set; }
        int TagId { get; set; }
    }
    
    public class OrderNote : INote
    {
        [Key]
        public int NoteId { get; set; }
        public virtual ICollection<INoteTag> NoteTags { get; set; }
    }
    public class OrderNoteTag : INoteTag
    {
        [Key]
        public int NoteTagId { get; set; }
        [ForeignKey("OrderNote")]
        public int TagId { get; set; }
        public virtual OrderNote OrderNote { get; set; }
    }
    
    public class ClientNote : INote
    {
        [Key]
        public int NoteId { get; set; }
        public virtual ICollection<INoteTag> NoteTags { get; set; }
    }
    public class ClientNoteTag : INoteTag
    {
        [Key]
        public int NoteTagId { get; set; }
        [ForeignKey("ClientNote")]
        public int TagId { get; set; }
        public virtual ClientNote ClientNote { get; set; }
    }
