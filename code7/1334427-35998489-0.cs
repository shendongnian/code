    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    
    namespace SO
    {
        public class Program
        {
            public static ConcurrentDictionary<string, int> teamInformation = new ConcurrentDictionary<string, int>();
    
            static void Main(string[] args)
            {
                Start();
    
                Console.WriteLine("ConcurrentDictionary contains : " + teamInformation.Count);
                Console.ReadKey();
            }
    
            static void Start()
            {
                for (var i = 0; i < 10; i++)
                {
                    var threadRequest = new Handler();
                    var thread = new Thread(() => threadRequest.ClientInteraction(teamInformation));
                    thread.Start();
                }
            }
        }
    
        public class Handler
        {
            public void ClientInteraction(ConcurrentDictionary<string, int> teamInformation)
            {
                for (var i = 0; i < 10; i++)
                {
                    teamInformation.AddOrUpdate(Guid.NewGuid().ToString(), i, (key, val) => val);
                }
            }
        }
    }
