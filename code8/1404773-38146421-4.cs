    public abstract class Votable
    {
        public abstract int TotalUpvotes { get; }
        public abstract int TotalDownvotes { get; }
        public virtual int TotalVoteScore { get { return TotalUpvotes - TotalDownvotes + 1; } }
    }
