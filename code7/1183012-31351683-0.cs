    var sw1 = new System.Diagnostics.Stopwatch();
    var sw2 = new System.Diagnostics.Stopwatch();
    //Version 1
    sw1.Start();
    for (int num = 0; num < 100; num += 2)
    {
        Console.WriteLine(num);
    }
    sw1.Stop();
    //Version 2
    sw2.Start();
    for (int num = 0; num < 100; num++)
    {
        if (num % 2 == 0)
        {
            Console.WriteLine(num);
        }
    }
    sw2.Stop();
    Console.Clear();
    Console.WriteLine("Ticks for first method: " + sw1.ElapsedTicks);
    Console.WriteLine("Ticks for second method: " + sw2.ElapsedTicks);
