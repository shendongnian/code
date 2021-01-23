    static async void DoSomething()
    {
        for(var i = 0;i<25;i++)
        {
            // Do Something
            await Task.Delay(1000);
            Console.WriteLine("Sending a Tweet");
        }
    }
