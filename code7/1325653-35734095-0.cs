    string sectionName = null;
    while (null != (line = streamReader.ReadLine()))
    {
        var sectionMatch = Regex.Match(line, @"\s*\[\s*(?<NAME>[^\]]+)\s*\]\s*");
        if (sectionMatch.Success)
        {
            sectionName = sectionMatch.Groups["NAME"].Value;
        }
        else if (sectionName == "HRData")
        {
            // You can process lines inside the `HRData` section here.
        }
    }
