    using (var sr = new StreamReader("C:\temp\file.txt"))
    {
        var results = Cawk.Execute(sr);
        foreach (item in results)
        {
            // do something with item which is Dictionary<string, object>
        }
    }
