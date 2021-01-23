    StringBuilder sb = new StringBuilder();
    bool skip = false;
    foreach (char c in "< harshal bhamare > sfjkgdbgfbguifg < fbgfg >")
    {
    	if (c.Equals('<')) skip = true;
    	if (c.Equals('>')) { skip = false; continue; }
    
    	if (!skip) sb.Append(c);
    
    }
    
    System.Console.WriteLine(sb.ToString());
