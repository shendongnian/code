    public abstract class CommentedObject
	{ 
	    public List<Comment> Comments {get; set;}
	
	public class Joke: CommentedObject
	{ 
	}
	public class  Story : CommentedObject
	{
	}
	public class Comment
	{
	     public Guid Id {get; set;}
	     public String Comment {get; set;}
	     [Key, ForeignKey ("IdentifiableObject")]
	     public Guid TargetId {get; set;}
	}
