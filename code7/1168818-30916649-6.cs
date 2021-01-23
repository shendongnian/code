    using (var writer = new StreamWriter(FILENAME1))
    {
        foreach (var element in StreamElements(r, "XML"))
        {
            var values = element.DescendantNodes()
                .OfType<XText>()
                .Select(e => Regex.Replace(e.Value, "\\s+", " "));
            var line = string.Join(",", values);
            writer.WriteLine(line);
        }
    }
