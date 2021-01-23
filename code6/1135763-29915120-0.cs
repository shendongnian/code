    public static IEnumerable<string> GetProducts(string path, Func<string, bool> matcher)
    {
    	using(var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
    	{
    		using(var reader = new StreamReader(stream))
    		{
    			do
    			{
    				var line = reader.ReadLine();
    				if (matcher(line)) yield return line
    			}while(!reader.EndOfFile)
    		}
    	}
    }
