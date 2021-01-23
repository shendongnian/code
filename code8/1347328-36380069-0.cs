    public class Article {
        [Key]
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Teaser { get; set; }
        [ForeignKey("UserID")]
        public virtual User Author {get; set; } // navigation property
        public int UserID { get; set; }
        public DateTime DateAdded { get; set; }
    }
