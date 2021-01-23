    public class MatchmakingService
    {
        private bool working;
        private List<MatchmakingUser> matchmakingUsers;
        // ...
        // the queue
        private List<NewMatchEventArgs> _queue = new List<NewMatchEventArgs>();
        public MatchmakingService()
        {
            matchmakingUsers = new List<MatchmakingUser>();
        }
        public void StartService()
        {
            var thread = new Thread(this.MatchmakingWork);
            working = true;
            thread.Start();
        }
        void MatchmakingWork()
        {
            while (working)
            {
                // some work, match found!
                {
                    lock (_queue)
                        _queue.Add(new NewMatchEventArgs(matchmakingUsers[1], matchmakingUsers[2]));
                }
                Thread.Sleep(1000);
            }
        }
        public void Update()
        {
            NewMatchEventArgs[] copyOfQueue;
            // create a copy (bulk action)
            lock (_queue)
            {
                copyOfQueue = _queue.ToArray();
                _queue.Clear();
            }
            // handle the items
            if (onMatchFound != null)
                foreach (var item in copyOfQueue)
                    onMatchFound(this, item); // indices are examples
        }
        public event EventHandler<NewMatchEventArgs> onMatchFound;
    }
