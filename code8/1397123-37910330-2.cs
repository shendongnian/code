    bool inQuote = false; 
    bool inComma = true;
    List<string> words = new List<string>();
    StringBuilder sb = new StringBuilder();
    foreach (char c in input) 
    {
       if(c == '"')
       {
          if(inQuote)
          {
             inComma = false;
             if(!String.IsnullOrEmpty(sb.ToString()) 
             {
                 words.Add(sb.ToString().Trim;
                 sb.Clear();
             }
             inQuote = !inQuote;              
             continue;
          }
       }
       if (c == ',' && !inQuote)
       {
          if(inComma)
          {
             if(!String.IsnullOrEmpty(sb.ToString()) 
             {
                 words.Add(sb.ToString().Trim;
                 sb.Clear();
             }
             inComma = !inComma; 
             continue;
          }
       }
       sb.Add(c);
    }
    if(!String.IsnullOrEmpty(sb.ToString()) 
       words.Add(sb.ToString().Trim());
    sb.Clear();
    foreach (string s in words) 
    {
       if(sb.Len > 0)
          sb.Append(", ");
       sb.Append(@"\"" + s + @"\""); // not sure if the is the correct syntax for "
    }
    Console.WriteLine(sb.ToString();
