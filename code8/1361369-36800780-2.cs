    class Dispatcher
    {
        // cache chained instances of handlers
        private static HandlerBase<RequestBase, ResponseBase> handler = RegisterHandlers();
        public static ResponseBase Dispatch(RequestBase request)
        {
            return handler.Execute(request);
        }
        private static HandlerBase<RequestBase, ResponseBase> RegisterHandlers()
        {
            // Build chain
            HandlerBase<RequestBase, ResponseBase> contextChain = new RequestAHandler(null);
            contextChain = new RequestBHandler(contextChain);
            // register new handlers here e.g.
            // contextChain = new RequestXHandler(contextChain);
            return contextChain;
        }
    }
