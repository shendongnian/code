    public class Game
    {
        private SynchronizationContext context;
        public Game()
        {
            context = SynchronizationContext.Current ??
                new SynchronizationContext();
        }
        public MethodInvoker Complete;
        public void Load()
        {
            //...
        }
        private void OnComplete()
        {
            if (Complete != null)
            {
                context.Post(_ => Complete(), null);
            }
        }
    }
