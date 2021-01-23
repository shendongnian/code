    async Task Main()
    {
        Console.WriteLine("before await startnew");           1
        await Task.Factory.StartNew(async () =>               2
        {
            Console.WriteLine("before await delay");          3
            await Task.Delay(500);                            4
            Console.WriteLine("after await delay");           5
        });
        Console.WriteLine("after await startnew");            6
    }
