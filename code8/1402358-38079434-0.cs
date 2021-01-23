    public static void UnionFiles()
    {
        var firstFilePath = "log1.txt";
        var secondFilePath = "log2.txt";
        var firstLogBlocks = ReadFileAsLogBlocks(firstFilePath);
        var secondLogBlocks = ReadFileAsLogBlocks(secondFilePath);
        var logsBlockNotInTheFirstFile = secondLogBlocks.Where(block => !firstLogBlocks.Contains(block)).ToList();
        var cleanLogBlock = firstLogBlocks.Concat(logsBlockNotInTheFirstFile);
        var cleanLog = new StringBuilder();
        foreach (var block in cleanLogBlock)
        {
            cleanLog.Append(block);
        }
        File.WriteAllText("cleanLog.txt", cleanLog.ToString());
    }
    private static List<LogBlock> ReadFileAsLogBlocks(string filePath)
    {
        var allLinesLog = File.ReadAllLines(filePath);
        var logBlocks = new List<LogBlock>();
        var currentBlock = new List<string>();
        var i = 0;
        foreach (var line in allLinesLog)
        {
            currentBlock.Add(line);
            if (i%5 == 0)
            {
                logBlocks.Add(new LogBlock(currentBlock.ToArray()));
                currentBlock.Clear();
            }
            i++;
        }
        return logBlocks;
    }
