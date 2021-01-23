    bool inQuote = false; 
    bool inComma = false;
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
    {
       words.Add(sb.ToString().Trim;
       sb.Clear();
    }
