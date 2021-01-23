    Task t = Task.Factory.StartNew(() =>
    {
        for (int ctr = 1; ctr <= 10; ctr++)
            Console.WriteLine(ctr.ToString() + "1");
    });
    
    await t; // calling task asynchronously
