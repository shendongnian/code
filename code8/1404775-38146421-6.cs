    public abstract class Votable
    {
        public abstract int TotalUpvotes { get; protected set; }
        public abstract int TotalDownvotes { get; protected set; }
        public virtual int TotalVoteScore { get { return TotalUpvotes - TotalDownvotes + 1; } }
    }
