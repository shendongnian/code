    public static string repl(Match m)
	{
    	return !string.IsNullOrEmpty(m.Groups[1].Value) ?
            m.Value.Replace(m.Groups[1].Value, string.Format("'{0}'", m.Groups[1].Value)) :
            m.Value;
	}
