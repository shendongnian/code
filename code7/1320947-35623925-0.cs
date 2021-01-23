    var task = Task.Run(() =>
    {
        try
        {
            Tester(cts);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception {0}", e.Message);
            throw;
        }
    }, cts.Token);
