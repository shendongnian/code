    static void Main(string[] args)
    {
        var list = PowerSet("node1", "node2", "node3");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
        Console.ReadLine();
    }
    private static List<string> PowerSet(params string[] input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("input");
        }
        // Power set contains 2^N subsets.
        var powerSetCount = 1 << input.Length;
            
        var returnValue = new List<string>();
        for (var setMask = 0; setMask < powerSetCount; setMask++)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < input.Length; i++)
            {
                // Checking whether i'th element of input collection should go to the current subset.
                if ((setMask & (1 << i)) > 0)
                    stringBuilder.Append(input[i]);
            }
            returnValue.Add(stringBuilder.ToString());
        }
        return returnValue;
    }
