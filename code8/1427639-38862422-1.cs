    var split_options = new [] {' ', '.', ',' ...}; // Use whatever you might have here.
	var input =  "#testing is #test".Split( split_options
                                          , StringSplitOptions.RemoveEmptyEntries);
	var word_to_replace = "#test";
	var new_text = "#cool";
	for (int i = 0; i < input.Length; i++)
	{
		if (input[i].Equals(word_to_replace))
		input[i] = new_text;
	}
	var output = string.Join(" ",input);
	// your output is "#testing is #cool"
