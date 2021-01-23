    public class Comment
    {
        public int CommentId { get; set; }
        public int RatingId { get; set; }
        public virtual Rating Rating { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
    }
    public class Rating
    {
        public Rating()
        {
            RatingPictures = new HashSet<RatingPicture>();
            Comments = new HashSet<Comment>();
        }
        public int RatingId { get; set; }
        public virtual ICollection<RatingPicture> RatingPictures { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public int LocationID { get; set; }
    }
    public class RatingPicture
    {
        public int RatingPictureId { get; set; }
        public int RatingId { get; set; }
        public virtual Rating Rating { get; set; }
        
    }
