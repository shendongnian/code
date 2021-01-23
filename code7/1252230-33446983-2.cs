    public abstract class Note
    {
        public int Id { get; set; }
        
        public string Comment {get; set; }
    }
    public class NoteForLot : Note
    {
        public int LotId { get; set; }
        public virtual Lot Lot { get; set; }
    }
    public class NoteForTask : Note
    {
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
