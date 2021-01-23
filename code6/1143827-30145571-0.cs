    public string[] GetQuestionsInRandomOrder()
    {
        var lines = File.ReadAllLines("test.txt");
        var rnd = new Random();
        var lines = lines.OrderBy(line => rnd.Next()).ToArray();
        return lines;
    }
