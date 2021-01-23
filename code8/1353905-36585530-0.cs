    public static List<string> MatchedLines(string[] MyArray)
    {
        return (from line in FileReadLinestoList(@"C:\Temp\MyFile.csv")
                where line.Split(',')[0] == MyArray[0] && line.Split(',')[1] == MyArray[1] 
                select line).ToList();
    }
        
