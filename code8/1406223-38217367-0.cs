        using(WebApp.Start<SelfHostConfiguration>(startOptions))
        {
            Console.WriteLine($"Service started and listening at {internalURL}");
            Console.ReadLine();
        }
