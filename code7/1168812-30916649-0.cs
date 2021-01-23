    using (var writer = new StreamWriter(FILENAME1))
    {
        foreach (var element in StreamElements(p, "XML"))
        {
            var values = element.Elements().Select(e => Regex.Replace(e.Value, "\\s+", " "));
            var line = string.Join(",", values);
            writer.Write(line);
        }
    }
