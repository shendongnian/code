    public interface IVotable
    {
        int TotalUpvotes { get; }
        int TotalDownvotes { get; }
        int TotalVoteScore { get; }
    }
    
    // shared implementation
    public class VoteStatus : IVotable
    {
        public int TotalUpvotes { get; private set; }
        public int TotalDownvotes { get; private set; }
        public int TotalVoteScore { get { return TotalUpvotes - TotalDownvotes + 1; } }
    }
    
    // has A...
    public class Comment : IVotable
    {
        // expose it?
        public IVotable VoteStatus { get; private set; }
    
        // allow current vote status to be injected?
        public Comment(IVotable voteStatusReference)
        {
            this.VoteStatus = voteStatusReference;
        }
    
        // or don't use injection?
        public Comment()
            : this(new VoteStatus())
        {
        }
    
        public int TotalUpvotes => this.VoteStatus.TotalUpvotes;
        public int TotalDownvotes => this.VoteStatus.TotalDownvotes;
        public int TotalVoteScore => this.VoteStatus.TotalVoteScore;
    }
