    bool overrideActive = false;
    while (!sr.EndOfStream)
    {
        string line = sr.ReadLine();
        if (line.Contains("CALL") && !line.Contains("//"))
        {                 
            if (line.Contains("WAIT('DI'")||line.Contains("WAIT('DO'"))
            {
                CommentOverride(line, newFilePath, overrideActive);
                overrideActive = true;
            }
            else
            {
                WriteLine(line, newFilePath);
                overrideActive = false;
            }
        }
    }
    private void CommentOverride(string code, string filePath, bool overrideActive)
    {
        if (!overrideActive)
        {
            WriteLineToFile("    :  ! BEGIN OVERRIDE COMMENT ;", filePath);
        }
        string commentedLine = code.Insert(5, "//");
        WriteLineToFile(commentedLine, filePath);
        if (!overrideActive)
        {
            WriteLineToFile("    :  ! END OVERRIDE COMMENT ;", filePath);
        }
    }
