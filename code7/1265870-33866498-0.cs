    var startFolder = @"D:\MyFiles";
    var filePattern = @"*.htm";
    var matchingFiles = Directory.EnumerateFiles(startFolder, filePattern, SearchOption.AllDirectories);
    foreach (var file in matchingFiles)
    {
        var lines = File.ReadLines(file, Encoding.UTF8);
        foreach (var line in lines)
        {
            if (line.StartsWith("AAA"))
            {
                // Do whatever needed with that line (call Substring, make a RegEx, etc.)
            }
        }
    }
