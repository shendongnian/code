    public static Task RealTimeDelay(TimeSpan delay) =>
        RealTimeDelay(delay, TimeSpan.FromMilliseconds(100));
    
    public static async Task RealTimeDelay(TimeSpan delay, TimeSpan precision)
    {
        DateTime start = DateTime.UtcNow;
        DateTime end = start + delay;
    
        while (DateTime.UtcNow < end)
        {
            await Task.Delay(precision);
        }
    }
