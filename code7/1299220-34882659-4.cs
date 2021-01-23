    sealed class MyCustomBinder : SerializationBinder, IDisposable
    {
        public MyCustomBinder()
        {
            AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
        }
    
        void IDisposable.Dispose()
        {
            AppDomain.CurrentDomain.AssemblyResolve -= OnAssemblyResolve;
        }
    
        // Your code here
    }
