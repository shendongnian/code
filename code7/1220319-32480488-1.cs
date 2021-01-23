    public class Document
    {
        public Document()
        {
            this.Comment = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Comment> Comment { get; set; } 
    }
