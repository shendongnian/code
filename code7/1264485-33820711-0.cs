    public class Rootobject
    {
    	public Class1[] Property1 { get; set; }
    }
    
    public class Class1
    {
    	public string type { get; set; }
    	public object score { get; set; }
    	public Show show { get; set; }
    	public Movie movie { get; set; }
    	public Person person { get; set; }
    }
    
    public class Show
    {
    	public string title { get; set; }
    	public string overview { get; set; }
    	public int year { get; set; }
    	public string status { get; set; }
    	public Images images { get; set; }
    	public Ids ids { get; set; }
    }
    
    public class Images
    {
    	public Poster poster { get; set; }
    	public Fanart fanart { get; set; }
    }
    
    public class Poster
    {
    	public string full { get; set; }
    	public string medium { get; set; }
    	public string thumb { get; set; }
    }
    
    public class Fanart
    {
    	public string full { get; set; }
    	public string medium { get; set; }
    	public string thumb { get; set; }
    }
    
    public class Ids
    {
    	public int trakt { get; set; }
    	public string slug { get; set; }
    	public int tvdb { get; set; }
    	public string imdb { get; set; }
    	public int tmdb { get; set; }
    	public int tvrage { get; set; }
    }
    
    public class Movie
    {
    	public string title { get; set; }
    	public string overview { get; set; }
    	public int year { get; set; }
    	public Images1 images { get; set; }
    	public Ids1 ids { get; set; }
    }
    
    public class Images1
    {
    	public Poster1 poster { get; set; }
    	public Fanart1 fanart { get; set; }
    }
    
    public class Poster1
    {
    	public string full { get; set; }
    	public string medium { get; set; }
    	public string thumb { get; set; }
    }
    
    public class Fanart1
    {
    	public string full { get; set; }
    	public string medium { get; set; }
    	public string thumb { get; set; }
    }
    
    public class Ids1
    {
    	public int trakt { get; set; }
    	public string slug { get; set; }
    	public string imdb { get; set; }
    	public int tmdb { get; set; }
    }
    
    public class Person
    {
    	public string name { get; set; }
    	public Images2 images { get; set; }
    	public Ids2 ids { get; set; }
    }
    
    public class Images2
    {
    	public Headshot headshot { get; set; }
    }
    
    public class Headshot
    {
    	public object full { get; set; }
    	public object medium { get; set; }
    	public object thumb { get; set; }
    }
    
    public class Ids2
    {
    	public int trakt { get; set; }
    	public string slug { get; set; }
    	public string imdb { get; set; }
    	public int tmdb { get; set; }
    	public int tvrage { get; set; }
    }
