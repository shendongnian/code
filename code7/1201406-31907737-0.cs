    string [] flame = {
    	"bad", "words", "inc"
    };
    string argsInput = "some bad ";
    //Regex regex = new Regex(@"\bad|\words|\inc");
    var sjoin = string.Join("|\\\\b", flame);
    
    Regex regex = new Regex ( sjoin , RegexOptions.IgnoreCase);
    Console.WriteLine(sjoin);
    Match match = regex.Match(argsInput);
    if (match.Success) {
    	Console.WriteLine("success");
    }
