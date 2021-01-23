    const int numOfFiles = 27;
    string[] lines = File.ReadAllLines(FileName);
    int numOfLines = lines.Length;
    int eachSubSet = numOfLines/numOfFiles;
    int firstSubset = numOfLines%numOfFiles + eachSubSet;
    IEnumerable<string> linesLeftToWrite = lines;
    for (int index = 0; index < numOfFiles; index++)
    {
        int numToTake = index == 0 ? firstSubset : eachSubSet;
        File.WriteAllLines(string.Format("{0}_{1}.txt", FileName, index), linesLeftToWrite.Take(numToTake));
        linesLeftToWrite = linesLeftToWrite.Skip(numToTake);
    }
