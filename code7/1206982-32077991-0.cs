    var dictionary = new Dictionary<string, string>
    {
        {"primarycolour", "blue"},
        {"secondarycolour", "red"}
    };
    
    string line_original =
    @"
    // Colour
    $primary-colour: if(@Model.PrimaryColour, @primaryColour, #afd05c);
    $secondary-colour: if(@secondaryColour, @secondaryColour, #323f47);
    // and so on
    ";
    
    Regex RxColors = new Regex( @"@Model\.(?<name>\w+)" );
    string line_new = RxColors.Replace(
    	line_original,
    	delegate(Match match)
    	{
    		string outVal;
    		if ( dictionary.TryGetValue( match.Groups["name"].Value.ToLower(), out outVal) )
    			return outVal;
    		return match.Groups[0].Value;
    	}
    );
    Console.WriteLine("New line: \r\n\r\n{0}", line_new );
