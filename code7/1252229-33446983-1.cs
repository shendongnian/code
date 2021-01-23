    public class Lot
    {
        public int LotId { get; set; }
        public virtual ICollection<NoteForLot> Notes { get; set; }
        public Lot()
        {
            Notes = new HashSet<NoteForLot>();
        }
    }
    public class Task
    {
        public int TaskId { get; set; }
        public virtual ICollection<NoteForTask> Notes { get; set; }
        public Task()
        {
            Notes = new HashSet<NoteForTask>();
        }
    }
