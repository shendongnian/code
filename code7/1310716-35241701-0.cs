    foreach (string line in lines)
    {
        // trim the line first
        var temp = line.Trim();
        
        // now perform all operation on the new temporary string
        string newline = temp.Remove(0, temp.IndexOf(' ') + 1);
        
        // debugging purpose
        Console.WriteLine(newline);
    }
