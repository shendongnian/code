    public class Bookmark
    {
       public int BookmarkID { get; set; }
       public string Url { get; set; }
       public ApplicationUser UserId { get; set; }
       public virtual ICollection<BookmarkTag> BookmarkTags { get; set; }
     }
    
     public class BookmarkTag
     {
        public int BookmarkTagID { get; set; }
        public virtual Bookmark Bookmark { get; set; }
        public virtual Tag Tag { get; set; }
     }
    
     public class Tag
     {
        public int TagID { get; set; }
        public string TagName { get; set; }
        public virtual ICollection<BookmarkTag> BookmarkTags { get; set; }
     }
