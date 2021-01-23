    static class Program
    {
        private static void Main()
        {
            ActorRuntime.RegisterActorAsync<MyActor>(
                (context, actorType) => new MyActorService(context, actorType, () => new MyActor()))
                .GetAwaiter().GetResult();
    
            Thread.Sleep(Timeout.Infinite);
        }
    }
