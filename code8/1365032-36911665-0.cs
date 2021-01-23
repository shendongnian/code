    public class StarSign
    	{
    		public string Name { get; set; }
    		public DateTime Start { get; set; }
    		public DateTime End { get; set; }
    	}
    
    	public class StarSignCalculator
    	{
    		public List<StarSign> Signs { get; set; }
    		public StarSignCalculator()
    		{
    			Signs = new List<StarSign>();
    			Signs.Add( new StarSign
    			{
    				Name = "Aquarius",
    				Start = new DateTime(9999, 1,20),
    				End = new DateTime(9999, 2, 18)
    			} );
    		}
    
    		public StarSign GetStarSign( int month, int day )
    		{
    			var theDate = new DateTime( 9999, month, day );
    			return Signs.FirstOrDefault( x => x.Start >= theDate && x.End <= theDate );
    		}
    	}
