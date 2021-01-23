    private static void Main()
    {
        int[] array = {3, 6, 4, 1, 3, 4, 2, 5, 3, 0};
        Console.WriteLine(IsSolvable(array));
        Console.ReadKey();
    }
    private static bool IsSolvable(int[] array)
    {
        if (!array.Any())
            return false;
        int number = array[0];
        if (number <= array.Length && array[number] == 0)
            return true;
        return IsSolvable(array.Skip(1).ToArray());
    }
