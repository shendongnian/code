    public static void Main()
    {
        Thread.Sleep(TimeSpan.FromMinutes(2));
        var myTask = Task.Run( () => WorkerTask())
        Task.Wait(myTask);
    }
    private static TimeSpan longToRun = new TimeSpan.FromMinutes(5);
    // easier to read than new TimeSpan(0,300,0));
    public static async Task WorkerTask()
    {
        StopTime = DateTime.Now + longToRun;
        // repeatedly wait a while and DoWork():
        while (DateTime.Now < StopTime)
        {
            await Task.Delay(TimeSpan.FromMinutes(2);
            DoWork();
        }
    }
