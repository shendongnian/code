    char[] array = "41sugar1100".ToCharArray();
    StringBuilder sb = new StringBuilder();
    
    // Append letters and special char '#' when original char is a number to split later
    foreach (char c in array)
    	sb.Append(Char.IsNumber(c) ? c : '#');
    
    // Split on special char '#' and remove empty string items
    string[] items = sb.ToString().Split('#').Where(s => s != string.Empty).ToArray();
        
    foreach (string item in items)
    	Console.WriteLine(item);
    // Output:  
    // 41  
    // 1100  
