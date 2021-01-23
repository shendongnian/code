    async Task IntermediateAsync()
    {
        Console.WriteLine("Press ESC to exit...");
        
        while (Console.ReadKey(true).Key != ConsoleKey.Escape)
        {
            var result = await _apiServiceOne.GetAsync();
            await _apiServiceTwo.PostAsync(result);
            // Wait ten milliseconds after each successful mediation phase
            await Task.Delay(10);
        }
    }
