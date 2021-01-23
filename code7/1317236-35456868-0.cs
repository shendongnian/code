     public class Bootstrapper
        {
            private IKernel _kernel = new StandardKernel();
    
            public Bootstrapper()
            {
                _kernel.Bind<MyStuff>().ToSelf();
                _kernel.Bind<IServiceLogger>().To<ServiceLogger>();
                _kernel.Bind<IMyService>().To<MyService>();
    
                _kernel.Bind<Func<IMyService>>().ToMethod(s => CreateService);
            }
    
            public IKernel Kernel
            {
                get
                {
                    return _kernel;
                }
                set
                {
                    _kernel = value;
                }
            }
    
            private IMyService CreateService()
            {
             
    
                if(_kernel.GetBindings(typeof(IServiceLogger)).Any())
                {
                    return _kernel.Get<IMyService>(new ConstructorArgument("logger", _kernel.Get<IServiceLogger>()));
                }
    
                return _kernel.Get<IMyService>();
            }
        }
