    private static IEnumerable<string> GetConsoleInputLines()
    {
        while (Console.In.Peek() >= 0)
            yield return Console.ReadLine();
    }
