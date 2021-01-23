    public class Movie
    {
    	public string Title { get; set; }
    
    	public Movie(MovieEntities.Movie movie)
    	{
    		this.Title = movie.Title;
    	}
    }
