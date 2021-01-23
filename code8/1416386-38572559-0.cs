    public class GenericIocFactory : IGenericIocFactory
    {
        public GenericIocFactory(ILifetimeScope scope)
        {
            this._scope = scope; 
        }
        private readonly ILifetimeScope _scope; 
        public T Get<T>(params object[] args) where T: class
        {           
            ConstructorInfo ci = this.GetConstructorInfo(args);
            if (ci == null) 
            {
                throw ...
            }
            
            var binder = new ConstructorParameterBinding(ci, args, this._scope);
            
            T value = binder.Instanciate() as T; 
            
            if (value == null) 
            {
                throw ...
            }
            if(value is IDisposable)
            {
                this._scope.Disposer.AddInstanceForDisposal(value);
            }
            return value; 
        }
        
        
        protected virtual ConstructorInfo GetConstructorInfo<T>(params object[] args)
        {
          // TODO 
        }
    }
