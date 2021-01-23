    List<string> inputHistories = new List<string>
    {
        inputhistory1, inputhistory2, inputhistory3, inputhistory4
    };
    public static bool checkfile(string filename)
    {
        return inputHistories.Any(filename =>
            File.ReadLines(filename).Any(line => line.Contains(filename)));
    }
