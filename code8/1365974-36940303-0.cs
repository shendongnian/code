    // Notice the ref keyword
    public static void CleanupHeaders(ref string _Col)
    {
	   _Col = _Col.Replace(@"\0K", "");
	   _Col = _Col.Replace(@"\b", "");
	   _Col = _Col.Replace(@"\0", "");
    }
