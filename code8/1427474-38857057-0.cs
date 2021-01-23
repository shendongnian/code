    public void QuoteEnclosingCSV(string fileNamePath)
    {
        var stringBuilder = new StringBuilder();
        foreach (var line in File.ReadAllLines(fileNamePath))
        {
            stringBuilder.AppendLine(string.Format("\"{0}\"", string.Join("\",\"", line.Split(','))));
        }
        File.WriteAllText(string.Format(fileNamePath, Path.GetDirectoryName(fileNamePath)), stringBuilder.ToString());
    }
