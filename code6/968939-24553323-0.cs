    public static IEnumerable<string> SplitEverySecond(this string input, string separator)
    {
    	if (input == null)
    	{
    		throw new ArgumentNullException("input");
    	}
    
    	var splitted = input.Split(new[] { separator }, StringSplitOptions.None);
    
    	for (var i = 0; i < splitted.Length; i += 2)
    	{
    		if (i + 1 >= splitted.Length)
    		{
    			yield return splitted[i];
    		}
    
    		yield return string.Join(separator, splitted[i], splitted[i + 1]);
    	}
    }
