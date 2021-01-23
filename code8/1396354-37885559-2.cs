    interface IMiddleware<TContext>
    {
       void Run(TContext context);
    }
    
    class Chain<TContext>
    {
        private List<IMiddleware<TContext>> handlers;
        void Register(IMiddleware<TContext> m);
        public void Run(TContext context)
        {
            handlers.ForEach(h => h.Run(context));
        }
    }
