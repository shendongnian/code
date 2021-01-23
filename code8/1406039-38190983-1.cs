    public static string GetString(string name, params object[] args)
    {
    	SR sR = SR.GetLoader();
    	if (sR == null)
    	{
    		return null;
    	}
    	string @string = sR.resources.GetString(name, SR.Culture);
    	if (args != null && args.Length != 0)
    	{
    		for (int i = 0; i < args.Length; i++)
    		{
    			string text = args[i] as string;
    			if (text != null && text.Length > 1024)
    			{
    				args[i] = text.Substring(0, 1021) + "...";
    			}
    		}
    		return string.Format(CultureInfo.CurrentCulture, @string, args);
    	}
    	return @string;
    }
