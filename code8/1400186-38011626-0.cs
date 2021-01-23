    var results = new List<string>();
    using (var sr = new StreamReader("C:\\Users\\sample.txt", true))
    {
        var s  = string.Empty;
        while ((s=sr.ReadLine()) != null)
        {
            results.AddRange(s.Split());
        }
    }
