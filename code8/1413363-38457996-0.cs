    public class Anime
    {
    	public int Id { get; set; }
    	public string Title { get; set;}
    	public string Description { get; set; }
    
    	public virtual ICollection<CommentAnime> Comments { get; set; }
    }
    public class CommentAnime
    {
    
	    public int Id { get; set; }
	    public string Opinion { get; set; }
	    public int Mark { get; set; }
	    
	    public int AnimeId { get; set; }
	    public virtual Anime anime { get; set; }
    }
