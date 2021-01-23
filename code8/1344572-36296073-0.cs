     var sb = new StringBuilder();
    
     foreach (char c in line)
     {
         if (char.IsDigit(c))
             sb.Append(c);
     }
    
     line = sb.ToString();
