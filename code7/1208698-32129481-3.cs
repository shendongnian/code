    private List<string> GetIPAddress()
    {
        var list = new List<string>();
        var input = File.ReadAllText("file.txt");
        var r = new Regex(@"(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}):(\d{1,5})");
        foreach (Match match in r.Matches(input))
        {
             string ip = match.Groups[1].Value;
             string port = match.Groups[2].Value;
             list.Add(ip);
             // you can also add port in the list
         }
         return list;
    }
