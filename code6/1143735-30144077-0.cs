    private static int Sum(int[] array, int startIndex)
    {
        if (startIndex >= array.Length)
        {
            return 0;
        }
        return array[startIndex] + Sum(array, startIndex + 1);
    }
    static void Main(string[] args)
    {
        int[] array = new int[] { 1, 2, 3, 4 };
        int result = Sum(array, 0);
        Console.WriteLine(result);
    }
