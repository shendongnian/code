    int[] x = new int[6] { 2, 4, 6, 8, 10, 12 };
    int[] y = new int[6] { 3, 6, 9, 12, 15, 18 };
    foreach (int i in x)
    {
        if (y.Contains(i))
        { 
            Console.WriteLine(i);//Print Matched items
        }
    }
   
