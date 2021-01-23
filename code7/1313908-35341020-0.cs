    private static string ReplaceRtfUnicodeChar(Match match) {
    	int number = Convert.ToInt32(match.Groups[1].Value);
    	char chr = (char)number;
    	return chr.ToString();
    }
    
    public static void Main(string[] args)
    {
    	string line= @"10 \u8314?\u8805? 0";
    	
    	var r = new Regex(@"\\u(\d*)\?");
    	string result = r.Replace(line, new MatchEvaluator(ReplaceRtfUnicodeChar));
    	
    	Console.WriteLine(result); // Displays 10 ⁺≥ 0
    }
