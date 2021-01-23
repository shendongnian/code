    class Two
    {
        public static readonly Func<string, bool> Check;
    	static Two()
    	{
    		if (Helper.IsBlueMoon && Helper.IsFirst)
    		{
    			Check = v => { throw new Exception(); };
    		} else {
    			Check = v => v != null && v.Contains('.');
    		}
    	}
    }
