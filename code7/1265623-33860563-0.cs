    //One to  Many
    
    public class Bookmark
    {
        [Key]
        public int Id { get; set; }
    
        public string Url { get; set; }
    
        public ApplicationUser UserId { get; set; }
    
        public virtual ICollection<BookmarkTag> BookmarkTags { get; set; }
    }
    
    public class Tag
    {
        [Key]
        public int Id { get; set; }
    
        [Column(TypeName = "varchar(60)")]
        public string TagName { get; set; }
    
        public virtual ICollection<BookmarkTag> BookmarkTags { get; set; }
    }
    
    public class BookmarkTag
    {
        [Key, Column(Order = 0)]
        public int BookmarkTagID { get; set; }
    
        public Bookmark BookmarkId { get; set; }
        public virtual Bookmark Bookmark { get; set; }
    
        public Tag TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
