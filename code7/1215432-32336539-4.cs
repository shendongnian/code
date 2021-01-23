    public class Books
    {
        public virtual int Id { get; set; }
        ...
        public virtual int CategoryId { get; set; }
        // all must be virtual
        //public Categories Categories { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual IList<Comments> Comments { get; set; }
