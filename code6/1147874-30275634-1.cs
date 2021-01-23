    static void Main(string[] args)
    {
        foreach (var numberRange in NumberRanges(14500, 58000, 10000))
        {
            Console.WriteLine(": {0}, {1}", numberRange.Min(), numberRange.Max());
        }
    }
    static IEnumerable<IEnumerable<int>> NumberRanges(int min, int max, int partitionSize)
    {
        int num = min;
 
        List<int> numPart = new List<int>(partitionSize);
        while (num <= max)
        {
            numPart.Add(num++);
            if (num % partitionSize == 0)
            {
                numPart.Add(num++);
                yield return numPart;
                numPart.Clear();
            }
        }
        if (numPart.Any())
            yield return numPart;
    }
