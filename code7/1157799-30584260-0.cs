    class Program
    {
        static void Main(string[] args)
        {
            Task waitForMe = Task.Run(() => waitAsync());
        }
        static async Task waitAsync()
        {
            await Task.Delay(5000);
        }
    }
