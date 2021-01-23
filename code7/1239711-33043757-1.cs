    static void Arrayreverse()
    {
        int[] arr = new int[100];
        Random r = new Random();
        for (int i = 0; i < 100; i++)
        {
            int rand = r.Next(0, 100);
            arr[i] = rand;
        }
        Array.Sort(arr);
        Array.Reverse(arr);
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(arr[i]);
        }
        Console.ReadKey();
    }
