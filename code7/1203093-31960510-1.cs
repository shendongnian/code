    // "abstract" tells EF, that this type doesn't require mapping
    public abstract class CommentBase
    {
        public int ID { get; set; }
        public int RelatedItemID { get; set; }
        public string Text { get; set; }
    }
    
    public class PageComment: CommentBase {}
    public class BlogPostComment :  CommentBase {}
    
    public abstract Base<TComment>
        where TComment : Comment
    {
        public int ID { get; set; }
        // ...
        public ICollection<TComment> Comments { get; set; }
    }
    
    public class Page : Base<PageComment> { /* other page properties */ }
    public class BlogPost : Base<BlogPostComment> { /* other blog post properties */ }
