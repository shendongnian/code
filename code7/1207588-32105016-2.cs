    public interface IHandlerFactory
    {
        dynamic Create(Type handlerType);
 
        void Release(dynamic handler);
    }
    public interface HandlerFactory
    {
        private readonly Func<Type, dynamic> handlerMethod;
        public HandlerFactory(Func<Type, dynamic> handlerMethod)
        {
            if (handlerMethod == null)
                throw new ArgumentNullException("handlerMethod");
            this.handlerMethod = handlerMethod;
        }
        public dynamic Create(Type handlerType)
        {
             return handlerMethod(handlerType);
        }
 
        public void Release(dynamic handler)
        {
            IDisposable disposable = handler as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
