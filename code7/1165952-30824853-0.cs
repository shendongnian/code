    var text = "line 1\rline 2\nline 3\r\nline 4";
    
    /* A regular expression that matches Windows newlines (\r\n),
        Unix/Linux/OS X newlines (\n), and old-style MacOS newlines (\r).
        The regex is processed left-to-right, so the Windows newlines
        are matched first, then the Unix newlines and finally the
        MacOS newlines. */
    var newLinesRegex = new Regex(@"\r\n|\n|\r", RegexOptions.Singleline);
    var lines = newLinesRegex.Split(text);
    
    Console.WriteLine("Found {0} lines.", lines.Length);
    
    foreach (var line in lines)
      Console.WriteLine(line);
