	public static class StringExtensions
	{
	  public class PatternsX
	  { 
	    public string Value {get;set;}
	  }
	
	  public static PatternsX Patterns(this string s)
	  {
	    return new PatternsX { Value = s};
	  }
	
	  public static string NumbersOnly(this PatternsX s)
	  {
	    return new String(s.Value.Where(Char.IsDigit).ToArray());
	  }
	}
