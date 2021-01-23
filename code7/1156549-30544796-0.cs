    public static void Main(string[] args)
    {
        List<List<int>> ar = new List<List<int>>();
        List<int> innerAr = new List<int>();
        for (int i = 1; i <= 9; i++)
        {
            innerAr.Add(i);
        }
        for (int j = 0; j <= 80; j++)
        {
            ar.Add(innerAr.ToList()); // <- here is the change
        }
        ar[80].RemoveAt(7);
        ar[80].RemoveAt(2);
        Console.WriteLine(ar[80].Count); // 7
        Console.WriteLine(ar[79].Count); // 9
    }
