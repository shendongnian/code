    public class Rating 
    {
    	/*Other properties*/
    	
    	public virtual ICollection<RatedFrom> RatedFromList {get; set;}
    	
    	public Rating()
    	{
    		/*Other properties initialization*/
    		RatedFromList = new List<RatedFrom>();
    	}
    }
