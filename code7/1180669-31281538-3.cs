    string input = @"
    &nbsp;
    &lt; <
    &#253; ý
    etc etc
    I have situations like word&nbsp;word and the nbsp gets recognized as a word.
    ";
    
    Regex RxNonEntWords = new Regex(@"(?i)(\w+)\b(?(?=;)(?<!(?:&|%)(?:[a-z]+|(?:\#(?:[0-9]+|x[0-9a-f]+)))(?=;)))");
    Match _m = RxNonEntWords.Match( input );
    while (_m.Success)
    {
    	Console.WriteLine("Found: {1}", _m.Groups[1].Value);
    	_m = _m.NextMatch();
    }
