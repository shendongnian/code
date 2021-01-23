    class Worker
    {
        private static readonly ManualResetEvent asTerminatedEvent = new ManualResetEvent(false);
        private ActorSystem actorSystem;
        public void Start()
        {
            this.actorSystem = ActorSystem.Create("sample");
        }
        public void Stop()
        {
            var cluster = Akka.Cluster.Cluster.Get(actorSystem);
            cluster.RegisterOnMemberRemoved(() => MemberRemoved(actorSystem));
            cluster.Leave(cluster.SelfAddress);
            asTerminatedEvent.WaitOne();
            //log.Info("Actor system terminated, exiting");
        }
        private async void MemberRemoved(ActorSystem actorSystem)
        {
            await actorSystem.Terminate();
            asTerminatedEvent.Set();
        }
    }
