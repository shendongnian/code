    public class Tag
    {
        public long Id { get; set; }
        public long SubjectId { get; set; }
        public long ConceptId { get; set; }
        public virtual Content Subject { get; set; }
        public virtual Concept Concept { get; set; }
    }
