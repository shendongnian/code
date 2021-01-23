    var fileName = @"YOUR FILE NAME";
    StringBuilder builder = new StringBuilder();
    using (StreamReader sr = new StreamReader(fileName))
    {
        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            var match = Regex.Match(line, @"{\s?get;\s?set;\s?}");
            if (match.Success)
            {
                var split = Regex.Split(line, @"{\s?get;\s?set;\s?}");
                var declaration = split[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var last = declaration.Count();
                var name = declaration[last - 1];
                builder.AppendLine(string.Format("[Column(\"{0}\")]", name));
            }
            builder.AppendLine(line);
        }
    }
