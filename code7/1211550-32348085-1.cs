      public sealed class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(BabySitterContext context)
            : base(context)
        {
        }
    }  
