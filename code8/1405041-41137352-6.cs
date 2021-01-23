    public class Tag
    {
        public int ID { get; set; }
        public string Term { get; set; }
        public virtual ICollection<Tag> Broader { get; set; }
        public virtual ICollection<Tag> Narrower { get; set; }
        public virtual ICollection<Tag> Equivalent { get; set; }
        public virtual ICollection<Tag> Related { get; set; }
        public virtual ICollection<Tag> Use { get; set; }
        public virtual ICollection<Tag> Usefor { get; set; }
        public Tag()
        {
            Broader = new HashSet<Tag>();
            Narrower = new HashSet<Tag>();
            Equivalent = new HashSet<Tag>();
            Related = new HashSet<Tag>();
            Use = new HashSet<Tag>();
            Usefor = new HashSet<Tag>();
        }
    }
