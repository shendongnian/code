    var fileInfo = new FileInfo(fileName);
    var className = fileInfo.Name.Split('.').Last();
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
                var declaredType = declaration[last - 2];
            }
        }
    }
