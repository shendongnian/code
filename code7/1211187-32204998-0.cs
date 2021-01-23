    public class Revision
    {
        public int Id { get; set; }
        ...
        public int? PreviousRevisionId { get; set; }
        public virtual Revision PreviousRevision { get; set; }
        public virtual ICollection<Revision > PreviousRevisions { get; set; }
    }
 
