    public static void Main(string[] args)
    {
        Enumerable.Range(1, 1000)
                    .AsParallel()
                    .ForAll( i => ManageConcurrency(i % 2,  () => Task.Delay(TimeSpan.FromSeconds(10))).Wait());
    }
    private static readonly ConcurrentDictionary<int, SemaphoreSlim> _lockDict = new ConcurrentDictionary<int, SemaphoreSlim>();
    private static async Task<bool> ManageConcurrency(int taskId, Func<Task> task)
    {
        var gate = _lockDict.GetOrAdd(taskId, _ => new SemaphoreSlim(1, 1));
        await gate.WaitAsync();
        try
        {
            Console.WriteLine($"{DateTime.Now.ToString("hh:mm:ss.ffffff")},  {taskId}, Lock pulled for TaskId {taskId}, Thread Id: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            await task();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
        finally
        {
            gate.Release();
        }
    }
