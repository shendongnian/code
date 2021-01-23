        var types = new List<string>();
        var previous = string.Empty;
        foreach (string line in text.Split(new string[] { "\r\n" }, StringSplitOptions.None))
            if (line.StartsWith("Sample id: "))
                types.Add(previous.Substring(0, previous.Length - line.Split(':')[1].Length));
            else
                previous = line;
