    static void MyTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        Console.WriteLine("Badness! Throwing exception");
        throw new ApplicationException("something bad happened");
    }
