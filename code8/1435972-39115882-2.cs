    int n = 2;
    int[] a = new int[n];
    string input = null;
    
    for (int i = 0; i < a.Length; i++) // or i < n if you want
    {
        print i;
        input = Console.ReadLine();
        try {
            a[i] = int.Parse(input);
            Console.WriteLine(string.Format(
                "You have inputted {0} for the {1} element",
                input, i
            ));
        } catch { Console.WriteLine("Non integer input"); i -= 1; }
    }
