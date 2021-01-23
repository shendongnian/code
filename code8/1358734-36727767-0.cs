    private static void Main()
    {
        int[] array = { 3, 6, 4, 1, 3, 4, 2, 5, 3, 0 };
        Console.WriteLine(IsSolvable(array));
        Console.ReadKey();
    }
    private static bool IsSolvable(int[] array, int index = 0)
    {
        while (index < array.Length)
        {
            int number = array[index];
            if (number <= array.Length && array[number] == 0)
                return true;
            return IsSolvable(array.Skip(index + 1).ToArray());
        }
        return false;
    }
