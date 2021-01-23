    public class Program
    {
        static string[] hosts = { "www.google.com", "www.facebook.com" };
        static void SendPing()
        {
            int numSucceeded = 0;
            using (ManualResetEvent alldone = new ManualResetEvent(false))
            {
                BackgroundWorker worker = null;
                ManualResetEvent[] handles = null;
                try
                {
                    worker = new BackgroundWorker();
                    DoWorkEventHandler doWork = (sender, args) =>
                    {
                        handles = new ManualResetEvent[hosts.Length];
                        for (int i = 0; i < hosts.Length; i++)
                            handles[i] = new ManualResetEvent(false);
                        numSucceeded = 0;
                        Action<int, bool> onComplete = (hostIdx, succeeded) =>
                        {
                            if (succeeded) Interlocked.Increment(ref numSucceeded);
                            handles[hostIdx].Set();
                        };
                        for (int i = 0; i < hosts.Length; i++)
                            SendPing(i, onComplete);
                        ManualResetEvent.WaitAll(handles);
                        foreach (var handle in handles)
                            handle.Close();
                    };
                    RunWorkerCompletedEventHandler completed = (sender, args) =>
                    {
                        Console.WriteLine("Succeeded " + numSucceeded);
                        BackgroundWorker bgw = sender as BackgroundWorker;
                        alldone.Set();
                    };
                    worker.DoWork += doWork;
                    worker.RunWorkerCompleted += completed;
                    worker.RunWorkerAsync();
                    alldone.WaitOne();
                    worker.DoWork -= doWork;
                    worker.RunWorkerCompleted -= completed;
                }
                finally
                {
				    if (handles != null)
				    {
                        foreach (var handle in handles)
                            handle.Dispose();
				    }
                    if (worker != null)
                        worker.Dispose();
                }
            }
        }
        static void SendPing(int hostIdx, Action<int, bool> onComplete)
        {
            using (Ping pingSender = new Ping())
            {
                PingCompletedEventHandler completed = null;
                completed = (sender, args) =>
                {
                    bool succeeded = args.Error == null && !args.Cancelled && args.Reply != null && args.Reply.Status == IPStatus.Success;
                    onComplete(hostIdx, succeeded);
                    Ping p = sender as Ping;
                    p.PingCompleted -= completed;
                    p.Dispose();
                };
                pingSender.PingCompleted += completed;
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                PingOptions options = new PingOptions(64, true);
                pingSender.SendAsync(hosts[hostIdx], 2000, buffer, options, hostIdx);
            }
        }
        private static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Send ping " + i);
                SendPing();
            }
        }
    }
