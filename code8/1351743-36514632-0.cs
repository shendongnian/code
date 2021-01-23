    public void Main()
    {
        var backgroundLoop = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                // This will be running in the backgroud
            }
        });
    
        Console.WriteLine("Continuing with the program while the loop is running. Loop completed? " + backgroundLoop.IsCompleted);
    
        backgroundLoop.Wait(); // Block here, and Wait until the loop is finished
    }
