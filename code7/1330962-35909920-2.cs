    public interface INote<T> where T : INoteTag
    {
        int NoteId { get; set; }
        ICollection<T> NoteTags { get; set; }
    }
    
    public interface INoteTag
    {
        int NoteTagId { get; set; }
        int TagId { get; set; }
    }
    
    public class OrderNote : INote<OrderNoteTag>
    {
        [Key]
        public int NoteId { get; set; }
        public virtual ICollection<OrderNoteTag> NoteTags { get; set; }
    }
    public class OrderNoteTag : INoteTag
    {
        [Key]
        public int NoteTagId { get; set; }
        [ForeignKey("OrderNote")]
        public int TagId { get; set; }
        public virtual OrderNote OrderNote { get; set; }
    }
    
    public class ClientNote : INote<ClientNoteTag>
    {
        [Key]
        public int NoteId { get; set; }
        public virtual ICollection<ClientNoteTag> NoteTags { get; set; }
    }
    public class ClientNoteTag : INoteTag
    {
        [Key]
        public int NoteTagId { get; set; }
        [ForeignKey("ClientNote")]
        public int TagId { get; set; }
        public virtual ClientNote ClientNote { get; set; }
    }
