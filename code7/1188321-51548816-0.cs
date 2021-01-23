    using System.Diagnostics;
    using System.Threading.Tasks;
    public static void ListenToParent(Action<string> onMessageFromParent)
    {
        Task.Run(async () =>
        {
            while (true) // Loop runs only once per line received
            {
                var text = await Console.In.ReadLineAsync();
                onMessageFromParent(text);
            }
        });
    }
