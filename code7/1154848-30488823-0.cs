    var oldLines = File.ReadAllLines(filePath):
    var newLines = oldLines.Select(FixLine).ToArray();
    File.WriteAllLines(filePath, newLines);
    string FixLine(string oldLine)
    {
        string fixedLine = ....
        return fixedLine;
    }
