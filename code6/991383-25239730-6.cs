    public static int GetLineNumber(string text, string lineToFind, StringComparison comparison = StringComparison.CurrentCulture)
    {
        int lineNum = 0;
        using (StringReader reader = new StringReader(text))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lineNum++;
                if(line.Equals(lineToFind, comparison))
                    return lineNum;
            }
        }
        return -1;
    }
