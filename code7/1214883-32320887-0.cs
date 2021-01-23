    public static void Main()
	{
		var result = "HelloThere";
    	Console.WriteLine(Regexes.rxAddSpaceBeforeCapital.Replace(result, " $1"));
    	result = "Hello  There";
    	Console.WriteLine(Regexes.rxAddSpaceBeforeCapital.Replace(result, " $1"));
	}
 
	public static class Regexes
	{
		public static readonly Regex rxAddSpaceBeforeCapital = new Regex(@"\s*(\p{Lu})", RegexOptions.Compiled);	
	}
