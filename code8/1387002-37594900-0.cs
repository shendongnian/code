    String source = 
      "a 123-456 up\nb 12-34-56 up\nc 987-55-4 beat";
    
    String pattern = "[0-9]+(-?[0-9]+)*";
    
    // [123-456, 12-34-56, 987-55-4]
    String[] matches = Regex.Matches(source, pattern)
      .OfType<Match>()
      .Select(match => match.Value)
      .Where(match => match.Count(c => c >= '0' && c <= '9') == 6) // exactly 6 digits
      .ToArray(); // optionally, if you want matches as an array
