    public class PlaceHolder
    {
    	public Random RND { get; set; } // Supplied random number generator
    
    	public string Pattern { get; set; } // User Pattern
    	public string Characters { get; set; } // Characters available to use
    	public string ReplaceChar              // Generated random character based on pattern.
    	{
    		get { return Characters[RND.Next( Characters.Length )].ToString(); }
    	}
    }
