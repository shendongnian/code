    if (Monitor.TryEnter(lockNum))
    {
        Console.WriteLine("No one else had the lock, now it's mine!");
    }
    else
    {
        Console.WriteLine("Another thread won :(");
    }
