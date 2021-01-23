    string workingDirectory = @"c:\";
    var days = new[] { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa" };
    var writers = new Dictionary<string, StreamWriter>();
    using (StreamReader sr = new StreamReader(workingDirectory + "data.csv"))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            var items = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StreamWriter w;
            if (!writers.TryGetValue(items[2], out w))
            {
                w = new StreamWriter(workingDirectory + items[2] + ".txt");
                writers.Add(items[2], w);
            }
            var times = items[1].Split(':');
            var digits = items.Skip(3)
                        .Select(x => { int i; return new { IsValid = int.TryParse(x, out i), Value = x }; })
                        .Where(x => x.IsValid).Select(x => x.Value);
            var data = new[] { Array.IndexOf(days, items[0]).ToString() }.Concat(times).Concat(digits);
            w.WriteLine(String.Join(",", data));
        }
    }
    foreach (var w in writers)
    {
        w.Value.Close();
        w.Value.Dispose();
    }
