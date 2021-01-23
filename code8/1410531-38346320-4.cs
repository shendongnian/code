    string line = @"{F971h}[0]<0>some result code: 1";
    var matchCollection = Regex.Matches(line, @"\{(?<timestamp>.*?)\}\[(?<subsystem>.*?)\]<(?<level>.*?)>(?<messagep>.*)");
    if (matchCollection.Count > 0)
    {
        string timestamp = matchCollection[0].Groups["timestamp"].Value;
        string subsystem = matchCollection[0].Groups["subsystem"].Value;
        string level = matchCollection[0].Groups["level"].Value;
        string messagep = matchCollection[0].Groups["messagep"].Value;
        Console.Out.WriteLine("First part is {0}, second: {1}, thrid: {2}, last: {3}", timestamp, subsystem, level, messagep);
    }
    else
    {
        Console.Out.WriteLine("No match found.");
    }
