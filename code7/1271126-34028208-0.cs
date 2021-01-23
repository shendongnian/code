    public static async Task<T> Retry<T>(Func<Task<T>> action)
    {
        for (var i = 0; ; i++)
        {
            try
            {
                return await action();
            }
            catch (Exception)
            {
                if (i >= 3)
                    throw;
            }       
        }
    }
    public static async Task Retry(Func<Task> action)
    {
        Func<Task<int>> d = async () => { await action(); return 0; };
        await Retry(d);
    }
