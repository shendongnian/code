    string  input = "\"efgh ,ijkl123,\",abcd ,  \"efgh ,ijkl123,\",mnop456 \"efgh ,ijkl123,\"";; 
    		
    Regex.Matches(input, "\"([^\"]*)\"(,)") // Extract string between quotes followed by ','.
    .Cast<Match>()
    	.ToList()
    	.ForEach(m=> input = input.Replace(m.Value, m.Value.Replace(",",";")) // for each match replace with ';' inserted match.
    							  .Replace(";\";",",\","));  // a hack, should have done it better
