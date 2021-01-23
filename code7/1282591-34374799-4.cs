    private static void Main(string[] args)
    {
        int number = 1;
        Timer timer = null;
        
        timer = new Timer((s) =>
        {
            Console.WriteLine(number++);
            if (number == 7)
                timer.Dispose();
        }, null, 0, 5000);
        Console.ReadLine();
    }
