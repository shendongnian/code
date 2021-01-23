    public class Comment : Votable
    {
        public override int TotalUpvotes { get; protected set; }
        public override int TotalDownvotes { get; protected set; }
    }
