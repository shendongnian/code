    public string[] GetQuestionsInRandomOrder()
    {
        var lines = File.ReadAllLines("test.txt");
        var rnd = new Random();
        lines = lines.OrderBy(line => rnd.Next()).ToArray();
        return lines;
    }
