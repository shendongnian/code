    while (sr.Peek() >= 0)
    {
        string line = sr.ReadLine();
        info = line.Split(new string[] { ", ", ",", "\"" }, StringSplitOptions.RemoveEmptyEntries);
        thisTime = DateTime.ParseExact(info[FileConstants.DATE], "yyyy-M-d H:m:s", null);
        if (thisTime > minimumDateTime && thisTime < maximumDateTime)
        {
            allInformation.Add(line);
        }
    }
