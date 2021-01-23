    /// <summary>Encodes the path portion of a URL string for reliable HTTP transmission from the Web server to a client.</summary>
    /// <returns>The URL-encoded text.</returns>
    /// <param name="str">The text to URL-encode. </param>
    public static string UrlPathEncode(string str)
    {
    	if (str == null)
    	{
    		return null;
    	}
    	int num = str.IndexOf('?');
    	if (num >= 0)
    	{
    		return HttpUtility.UrlPathEncode(str.Substring(0, num)) + str.Substring(num);
    	}
    	return HttpUtility.UrlEncodeSpaces(HttpUtility.UrlEncodeNonAscii(str, Encoding.UTF8));
    }
