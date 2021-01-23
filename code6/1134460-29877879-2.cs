    public partial class Post
    {
        public Post()
        {
            this.Tags = new HashSet<Tag>();
        }
        public int Id { get; set; }
        public string BlogUserEmail { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Meta { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        public System.DateTime PostedOn { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public byte[] Picture { get; set; }
        public string ImageToShow { get; set; }
        public virtual BlogUser BlogUser { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
    
