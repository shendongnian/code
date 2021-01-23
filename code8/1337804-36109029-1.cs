    static void Main() 
    {
        try
        {
            Task.WaitAll(new Task[] { 
                Task.Run(() => WriteFooToTextFile()),  // (A)
                Task.Run(() => WriteBarToTextFile())   // (B)
            });
        }
        catch (AggregateException e)
        {
            // Handle exception, display failure message, etc.
        }
    }
