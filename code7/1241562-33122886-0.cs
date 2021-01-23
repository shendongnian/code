    string text = "{  { 1, 3, 23 } ,  { 5, 7, 9 } ,  { 44, 2, 3 }  }";
    // remove spaces, makes parsing easier
    text = text.Replace(" ", string.Empty) ;
    
    var matrix = 
        // match groups
        Regex.Matches(text, @"{(\d+,?)+},?").Cast<Match>()
        .Select (m => 
            // match digits in a group
            Regex.Matches(m.Groups[0].Value, @"\d+(?=,?)").Cast<Match>()
            // parse digits into an array
            .Select (ma => int.Parse(ma.Groups[0].Value)).ToArray())
            // put everything into an array
            .ToArray();
