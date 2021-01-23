    List<string> data = new List<string>();
    data.Add("01:01 A car consists of : wheels, engine, seats");
    data.Add("01:02 A bike consists of : wheels");
    data.Add("01:03 A small truck consists of : wheels, engine, seats, bed");
    Regex regex = new Regex(@"^[\d]{2}:[\d]{2} A[n]? ([a-zA-Z\s]+) consists of : ([a-zA-Z,\s0-9]+)$");
    for (int i = 0; i < data.Count; i++)
    {
        var match = regex.Match(data[i]);
        Console.WriteLine(match.Groups[1].Value);
        var attributes = match.Groups[2].Value.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        string attstring = "";
        for (int a = 0; a < attributes.Length; a++)
        {
            if (attstring.Length > 0)
                attstring += ", ";
            attstring += attributes[a];
        }
        Console.WriteLine("    " + attstring);
    }
