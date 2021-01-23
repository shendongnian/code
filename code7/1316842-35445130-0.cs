    private static string EncodeValues(string xml)
    {
        var doc = new List<string>();
        var lines = xml.Split('\n');
        foreach (var line in lines)
        {
            var output = line;
            if (line.Contains("<Field") && !line.Contains("Fields>"))
            {
                var value = line.Parse(">", "</");
                var encoded = HttpUtility.UrlEncode(value);
                output = line.Replace(value, encoded);
            }
            doc.Add(output);
        }
        return string.Join("", doc);
    }
    private static Hashtable DecodeValues(IDictionary data)
    {
        var output = new Hashtable();
        foreach (var key in data.Keys)
        {
            var value = (string)data[key];
            output.Add(key, HttpUtility.UrlDecode(value));
        }
        return output;
    }
