    async static Task<int> AsyncCheck()
    {
       await Task.Factory.StartNew( async () => 
        {
            Console.WriteLine("Start awesome work");
            await Task.Delay(1000);
            Console.WriteLine("Almost done");
            await Task.Delay(1000);
            Console.WriteLine("Ok, done!");
        });
    
       return 42;
    }
    
    async static void AsyncCall()
    {
        int result = await AsyncCheck();
        Console.WriteLine(result);
    }
