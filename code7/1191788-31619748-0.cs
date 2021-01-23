    static void Main(string[] args)
    {
        int[] first = {10, 11, 12, 13, 14, 15, 16, 17, 18, 19};
        int[] second = new int[first.Length + 1]; // One extra position.
        Array.Copy(first, 0, second, 1, 10);
        foreach (int x in second)
        { 
            Console.WriteLine("{0}", x);
        }
        Console.ReadKey();
    }
}
