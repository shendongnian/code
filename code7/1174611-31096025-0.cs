        public int Id { get; set; }
        public List<CommentLike> Likes { get; set; }
        public int PostId { get; set; }
        public Comment()
        {
            Likes = new List<CommentLike>();
        }
    }
    public class Like
    {
        public int Id { get; set; }
    }
    public class Post
    {
        public int Id { get; set; }
        public List<PostLike> Likes { get; set; }
        public List<PostComment> Comments { get; set; }
        public Post()
        {
            Likes = new List<PostLike>();
            Comments = new List<PostComment>();
        }
    }
    public class PostComment : Comment
    {
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
    public class LikeComment : Comment
    {
        public int LikeId { get; set; }
        [ForeignKey("LikeId")]
        public virtual Like Like { get; set; }
    }
    public class PostLike : Like
    {
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
    public class CommentLike : Like
    {
        public int CommentId { get; set; }
        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }
    }
