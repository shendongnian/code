    static void Main(string[] args)
    {
        int[] first = {10, 11, 12, 13, 14, 15, 16, 17, 18, 19};
        int[] second = new int[first.Length];
        for (int k = 0; k < first.Length; k++)
            second[(k == (first.Length - 1))? 0: k + 1] = first[k];
        foreach (int x in second)
        { 
            Console.WriteLine("{0}", x);
        }
        Console.ReadKey();
    }
