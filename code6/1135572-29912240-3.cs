    string[] ReadAllResourceLines(string resourceName)
    {
        using (Stream stream = Assembly.GetEntryAssembly()
            .GetManifestResourceStream(resourceName))
        using (StreamReader reader = new StreamReader(stream))
        {
            EnumerateLines(reader).ToArray();
        }
    }
    IEnumerable<string> EnumerateLines(TextReader reader)
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            yield return line;
        }
    }
