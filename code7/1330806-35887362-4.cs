     /// <summary>Encodes a URL string.</summary>
     /// <returns>An encoded string.</returns>
     /// <param name="str">The text to encode. </param>
     public static string UrlEncode(string str)
     {
    	if (str == null)
    	{
    		return null;
    	}
    	return HttpUtility.UrlEncode(str, Encoding.UTF8);
     }
