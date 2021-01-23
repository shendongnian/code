    public partial class Post : IHasID
    {
        [NotMapped]
        public int Id 
        {
            get { return PostId; }
            set { PostId = value; }
        }
        
        public int PostId { get; set; }
        ...
