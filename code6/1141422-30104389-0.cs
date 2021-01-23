    string line = "first,\"second, second\",\"\"\"third\"\" third\",\"\"\"fourth\"\", fourth\"";
    var substringArray = new List<string>();
    string substring = null;
    var doubleQuotesCount = 0;
    
    for (var i = 0; i < line.Length; i++)
    {
      if (line[i] == ',' && (doubleQuotesCount % 2) == 0)
      {
        substringArray.Add(substring);
        substring = null;
        doubleQuotesCount = 0;
        continue;
      }
      else
      {
        if (line[i] == '"')
          doubleQuotesCount++;
                                           
        substring += line[i];
    
        //If it is a last character
        if (i == line.Length - 1)
        {
          substringArray.Add(substring);
          substring = null;
          doubleQuotesCount = 0;
        }
      }
    }
    
    for(var i = 0; i < substringArray.Count; i++)
    {
      if (substringArray[i] != null)
      {
        //remove first double quote
        if (substringArray[i][0] == '"')
        {
          substringArray[i] = substringArray[i].Substring(1);
        }
        //remove last double quote
        if (substringArray[i][substringArray[i].Length - 1] == '"')
        {
          substringArray[i] = substringArray[i].Remove(substringArray[i].Length - 1);
        }
        //Replace double double quotes with single double quote
        substringArray[i] = substringArray[i].Replace("\"\"", "\"");
      }
    }
