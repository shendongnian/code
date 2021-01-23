    public static async Task TaskDoWork()
    {
        using (var dispose = new TaskDispose())
        {
           await dispose.RunAsync();
        }
    }
