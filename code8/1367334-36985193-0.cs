    public string[] Parser(string caminho)
    {
        string text = File.ReadAllText(caminho);
        var foo = Regex.Replace(text, @"\/\**?\*\/", " ");
        var lines = foo.Split(new[]{'/'}, StringSplitOptions.RemoveEmptyEntries)
           .Where(line => !string.IsNullOrWhiteSpace(line))
           .ToArray();
        return lines;
    }
