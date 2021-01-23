    string format(string col1, string col2, string col3)
	{
        var sb = new StringBuilder();
        while(col1.Length > 4 || col2.Length > 10 || col3.Length > 5)
        {
            sb.AppendLine(CreateLine(ref col1, ref col2, ref col3));
        }
        return sb.ToString();
	}
    string CreateLine(ref string col1, ref string col2, ref string col3)
    {
        var returnValue = string.Format("{0} {1} {2}", 
                                col1.Substring(0, Math.Min(col1.Length, 4)).PadRight(4), 
                                col2.Substring(0, Math.Min(col2.Length, 10)).PadRight(10), 
                                col3.Substring(0, Math.Min(col3.Length, 5)).PadRight(5));
        if (col1.Length > 4) 
            col1 = col1.Substring(4, col1.Length - 4);
        if (col2.Length > 10) 
            col2 = col2.Substring(10, col2.Length - 10);
        if(col3.Length > 5)
            col3 = col3.Substring(5, col3.Length - 5);
        return returnValue;
    }
