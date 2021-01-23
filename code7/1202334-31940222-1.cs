    //...
    while ((line = r.ReadLine()) != null)
    {
        var re = Regex.Match(line, @"(\d+)");
        if (re.Success) 
        {
            var val = re.Groups[1].Value; 
            lines.Add(val);
        }
    }
    //...
