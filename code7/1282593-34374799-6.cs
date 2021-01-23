    private static void Main(string[] args)
    {
        Print(1, 6, TimeSpan.FromSeconds(5)); //This doesn't cause the thread to wait
        //Do something else if you want
        Console.ReadLine();
    }
    private async static Task Print(int from, int to, TimeSpan every)
    {
        for (int number = from; number <= to; number ++)
        {
            Console.WriteLine(number);
            await Task.Delay(every);
        }
    }
