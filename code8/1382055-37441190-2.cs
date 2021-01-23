        foreach (var line in lines.Skip(1))
        {
            var fields = line.Trim(new char[] { '"' }).Split(new string[] { "\", \"" }, StringSplitOptions.None);
            Entry entry = new Entry { Name = fields.FirstOrDefault(), Age = fields.Skip(1).FirstOrDefault(), Sex = fields.LastOrDefault() };
            results.Add(entry);
        }
        var json = JsonConvert.SerializeObject(results);
