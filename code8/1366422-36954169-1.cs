    var lines = new List<string>();
    // read lines from file to lines list
    
    var stringBuilder = new StringBuilder();
    
    foreach(var line in lines)
    {
        var semicolonCount = line.Count(x => x == ';');
        var resultLine = line;
        if(0 < semicolonCount < 3)
        {
            resultLine = resultLine.Replace(System.Environment.NewLine, string.Empty);
        }
        
        stringBuilder.Append(line);
    }
    
    var resultText = stringBuilder.ToString();
    // write this into the file
