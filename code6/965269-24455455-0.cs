    public class Filter
    	{
    
    		public enum Op 
    		{
    			Equals,
    			GreaterThan,
    			LessThan,
    			GreaterThanOrEqual,
    			LessThanOrEqual,
    			Contains,
    			StartsWith,
    			EndsWith
    		}
    
    		public string PropertyName { get ; set ; }
    		public Op Operation { get ; set ; }
    		public object Value { get ; set ; }
    	}
