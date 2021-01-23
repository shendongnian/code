    public static IEnumerable<string[]> GetAllCombinations(string[,] input, Stack<string> current = null, int currentCol = 0)
    {
        if (current == null) current = new Stack<string>();
        var rows = input.GetLength(0);
        var cols = input.GetLength(1);
        for (var row = 0; row < rows; row++)
        {
            if (input[row, currentCol] == null) continue;
            current.Push(input[row, currentCol]);
            if (currentCol == cols - 1)
            {
                var result = current.ToArray();
                Array.Reverse(result);
                yield return result;
            }
            else
            {
                var subResults = GetAllCombinations(input, current, currentCol + 1);
                foreach (var subResult in subResults)
                    yield return subResult;
            }
            current.Pop();
        }
    }
    static void Main()
    {
        var input = new[,]
        {
            {"bear", "claw", "donut"},
            {"chicken", "salad", null},
            {"tuna", null, "salad"}
        };
        foreach (var comb in GetAllCombinations(input))
            Console.WriteLine(string.Join(",", comb));
    }
