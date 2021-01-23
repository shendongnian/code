    var prev;
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
    
        if (line.Contains("X")) {
            // Processing both line and prev
        }
    
        prev = line; // remember previous line for future use
    }
