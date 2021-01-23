    public static void Main()
    {
        Program p = new Program();
        int sum = p.Add(20, 40);
        Console.WriteLine("The sum of 20 and 40 is " + sum);
        p.print1();
        p.print2();
        Console.ReadKey();
    }
