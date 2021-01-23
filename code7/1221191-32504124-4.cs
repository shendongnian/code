    // Note I'm going to use HashSet<T> everywhere because both movies and
    // users should be unique in their respective collections
    public class User 
    {
    	public sealed class UserEqualityComparer : IEqualityComparer<User>
    	{
    		  public bool Equals(User a, User b)
    		  {
    			  return a != null && b != null && a.Name == b.Name;
    		  }
    	
    		  public int GetHashCode(User some)
    		  {
    			  return some.Name.GetHashCode();
    		  }
    	}
    
     
         public string Name { get; set; }
    
         // C# 6 expression bodied properties!!!!
         public HashSet<Movie> LikesMovies { get; set; } = new HashSet<Movie>(new Movie.MovieEqualityComparer());
    }
    
    public class Movie
    {	
    	public sealed class MovieEqualityComparer : IEqualityComparer<Movie>
    	{
    		  public bool Equals(Movie a, Movie b)
    		  {
    			  return a != null && b != null && a.Name == b.Name;
    		  }
    	
    		  public int GetHashCode(Movie some)
    		  {
    			  return some.Name.GetHashCode();
    		  }
    	}
    	
         public string Name { get; set; }
         
         // C# 6 expression bodied properties!!!!
         public HashSet<User> UsersWhoLikeIt { get; set; } = new HashSet<User>(new User.UserEqualityComparer());
    }
