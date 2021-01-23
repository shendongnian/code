    const int lastNChars = 4;
    var patterns = new string[]{@"8062", @"\+13066598273", @"4083100", 
    		@"408320[0-3]", @"408320[4-6]", @"752[234569]", 
    		@"\+13066598305", @"8059"};
    var range = Enumerable.Range(0, (int) Math.Pow(10, lastNChars))
                .Reverse().ToArray();
    var sortedPatterns = patterns.OrderBy(pattern=> {
    	var len = lastNChars + pattern.Length 
    			- Regex.Replace(pattern, @"\[[^\]]+\]", "X").Length;
        // Get the biggest number in range that matches this regex:
    	var biggestNumberMatched = range.FirstOrDefault(x => 
    		Regex.IsMatch(x.ToString(new String('0', lastNChars)), 
    		    		pattern.Substring(pattern.Length - len, len))
    	);
        return biggestNumberMatched;
    }).ToArray();
