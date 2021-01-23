    var lines = new List<string>();
    // read lines from file to lines list
    
    var stringBuilder = new StringBuilder();
    
    foreach(var line in lines)
    {        
        stringBuilder.Append(line);
        var semicolonCount = line.Count(x => x == ';');
        if(semicolonCount == 0 || semicolonCount > 2)
        {
            stringBuilder.Append(Environment.NewLine);
        }
    }
    
    var resultText = stringBuilder.ToString();
    // write this into the file
