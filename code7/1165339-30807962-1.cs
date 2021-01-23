    Regex r = new Regex("^.*\\.(ext|doc|PUT_OTHER_EXTENSIONS_HERE)$");
    var fileNames =  File.ReadAllLines(FILE_PATH)
                .Where(x => !string.IsNullOrWhiteSpace(x) &&
                    r.Match(x.Split(new string[] { "'" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim()).Success)
                    .Select(x => x.Split(new string[] { "'" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim());
