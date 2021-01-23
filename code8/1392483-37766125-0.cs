    static void Main(string[] args)
    {
        List<int> input = new List<int>();
        for (int i = 0; i <= 50; i++)
        {
            input.Add(i);
        }
        List<List<int>> output = input.Select((x, i) => new { x = x, i = (int)(x / 10) }).GroupBy(y => y.i).Select(z => z.Select(a => a.x).ToList()).ToList();
    }
