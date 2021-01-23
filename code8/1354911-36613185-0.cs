    string input = "abcd ,  \"efgh ,ijkl123,\",mnop456";
    
    Regex.Matches(input, "\"([^\"]*)\"") // Extract string between quotes.
         .Cast<Match>()
    	 .ToList()
    	. ForEach(m=> input = input.Replace(m.Value, m.Value.Replace(",",";"))); // for each match replace with ';' inserted match.
