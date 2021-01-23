    // Triggers every minute (every time the clock looks like 00:xx:xx)
    public static void CronJob([TimerTrigger("0 * * * * *")] TimerInfo timer, [Queue("Foo")] out string message)
    {
        Console.WriteLine("Cron job fired!");
        message = "Hello world!";
    }
    public static void QueueJob([QueueTrigger("Foo")] string message)
    {
        Console.WriteLine(message);
    }
