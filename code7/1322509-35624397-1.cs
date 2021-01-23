    public static class EmailHelper
    {
    	private static string _templateString;
    	private const string APP_KEY = "EmailTemplate";
    	
    	public static string TemplateString
    	{
    		get
    		{
    			// Lazy loading pattern at Application's level
    			if (_templateString == null)
				{
					// if also null, fetch from your persistance layer
					if (Application[APP_KEY] == null)
					{
						var template = System.IO.File.ReadAllText(@"C:\Temp\Delete Anytime\EmailBody.txt");
						Application[APP_KEY] = template;
						_templateString = template;
					}
				}
    			return _templateString;
    		}
    		set
    		{			
				// value should come from reading your text file
    			Application[APP_KEY] = value;
    			// cache invalidation
    			_templateString = null;
    		}
    	}
    	
    	public static string ResolvePlaceholders(Dictionnary<string, string> keyValuePairs)
    	{
    		// initiate a string builder from the template
    		var contentBuilder = new StringBuilder(TemplateString);
    		// dictionnary keys are your placeholders
    		// values are actual content
    		foreach(var kvp in keyValuePairs)
    		{
    			contentBuilder.Replace(kvp.Key, kvp.Value);
    		}
    		return contentBuilder.ToString();
    	}
    }
