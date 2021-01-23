      string source = ...
    
      string key = "Exif Byte Order";  
    
      var result = source
        .Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries)
        .Select(line => {
           int index = line.IndexOf(key, StringComparison.OrdinalIgnoreCase);
    
           return index < 0 ? null : line.Substring(index + key.Length).Trim();
         })
        .FirstOrDefault(line => line != null);
    
      // Little - endian(Intel, II)
      Console.Write(result);
