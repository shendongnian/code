    class Worker
    {
        private ActorSystem actorSystem;
    
        public void Start()
        {
            this.actorSystem = ActorSystem.Create("sample");
        }
    
        public void Stop()
        {
            Task<Done> shutdownTask = CoordinatedShutdown.Get(actorSystem).Run(CoordinatedShutdown.ClrExitReason.Instance);
            shutdownTask.Wait();
        }
    
    }
