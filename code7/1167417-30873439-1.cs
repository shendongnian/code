    private static async Task MainAsync()
    {
        var transformBlock = new TransformBlock<int, int>(async input =>
        {
            await Task.Delay(RandomGen2.Next(5, 100));
            return input;
        }, new ExecutionDataflowBlockOptions {MaxDegreeOfParallelism = 10});
        foreach (var number in Enumerable.Range(0,100))
        {
            await transformBlock.SendAsync(number);
        }
        for (int i = 0; i < 100; i++)
        {
            var result = await transformBlock.ReceiveAsync();
            Console.WriteLine(result);
        }
    }
