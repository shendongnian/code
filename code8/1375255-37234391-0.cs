    public static void Main(string[] args)
    {
        ... ... ...
        int basicOperations;
        int searchPos = IntArrayBinarySearch(arr, arr[5], out basicOperations);
        Console.WriteLine("Found at {0} basic ops={1}", searchPos, basicOperations);
    }
    public static int IntArrayBinarySearch(int[] data, int item, out int basicOperations)
    {
        var min = 0;
        var N = data.Length;
        var max = N - 1;
        basicOperations = 0;
        basicOperations++;
