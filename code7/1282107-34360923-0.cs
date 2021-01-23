    private const object theLock = new object();
    private static volatile int currentNumber = 0; // note the addition of "volatile"
    private static void OutputNum()
    {
        lock (theLock)
        {
            currentNumber++;
            Console.WriteLine(currentNumber);
        }
    }
