    public abstract class VotableBase
    {
        public int TotalUpvotes { get; protected set;}
        public int TotalDownvotes { get; protected set; }
        public int TotalVoteScore { get { return TotalUpvotes - TotalDownvotes + 1 ; } }
    }
