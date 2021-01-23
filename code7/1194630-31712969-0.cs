    public static string Repl(Match m)
	{
		double result = Convert.ToDouble(m.Groups[3].Value);
		result = Convert.ToDouble(m.Groups[3].Value) / 100 * 2;
        if (result < 0 || m.Index == 0)
           return m.Value.Replace(m.Groups[3].Value, result.ToString());
        else 
           return m.Value.Replace(m.Groups[3].Value, "+" + result.ToString());
	}
