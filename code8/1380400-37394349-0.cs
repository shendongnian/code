    IEnumerable<string> Strings()
    {
    	var digits = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    	var chars = Enumerable.Range((int)'A', (int)'Z' - (int)'A' + 1).Select(i => (char)i).ToArray();
    	for (var c = 0L; c < Math.Pow(chars.Length, 5); ++c)
    	{
    		var cstr = chars[(c / (chars.Length * chars.Length * chars.Length * chars.Length) % chars.Length)].ToString()
    				 + chars[(c / (chars.Length * chars.Length * chars.Length) % chars.Length)]
    				 + chars[(c / (chars.Length * chars.Length) % chars.Length)]
    				 + chars[(c / (chars.Length) % chars.Length)]
    				 + chars[(c % chars.Length)];
    		
    		for (var i = 0L; i < 999; ++i)
    		{
    			var istr = (i / 100 % 10).ToString()
    					 + (i / 10 % 10).ToString()
    					 + (i % 10).ToString();
    
    			var str = cstr.Substring(0, 2) + istr.Substring(0, 1) + cstr.Substring(2, 2) + istr.Substring(1, 1) + cstr.Substring(4, 1) + istr.Substring(2, 1);
    			yield return str;
    		}
    	}
    }
