    var lines = File.ReadAllLines(filePath);
    int lineIndex;
    for (lineIndex = 0; lineIndex < lines.Length - 1; lineIndex++)
    {
        if (lines[lineIndex] == textToFind)
        {
            break;
        }
    }
    var startLine = Math.Max(0, lineIndex - 6);
    for (int i = startLine; i < lineIndex; i++)
    {
        Console.WriteLine(lines[i]);
    }
