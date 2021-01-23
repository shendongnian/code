	public interface IVotable
	{
	    int TotalUpvotes { get; }
	    int TotalDownvotes { get; }
	    int TotalVoteScore { get; }
	}
	
	public abstract class VotableBase : IVotable
	{
		public abstract int TotalUpvotes { get; protected set; }
		public abstract int TotalDownvotes { get; protected set; }
		public virtual int TotalVoteScore { get { return TotalUpvotes - TotalDownvotes + 1 ; } }
	}
	
	public class Comment : VotableBase
	{
	    public override int TotalUpvotes { get; protected set; }
	    public override int TotalDownvotes { get; protected set; }
	}
