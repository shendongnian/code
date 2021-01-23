    foreach (string line in File.ReadLines(dlgFile.FileName))
    {
        var parts = line.Split(':');
        if (parts.Length == 2)
        {
             var key = parts[0];
             var value = parts[1];
             Dict.TryAdd(key, value);
        }
        else
        {
             // log that line was ignored
        }
    }
