     public class MyApplicationNavigator : INavigator
        {
            private readonly IShell _shell;
    
            public MyApplicationNavigator(IShell shell)
            {
                _shell = shell;
            }
            public INavigationRequest<T> To<T>()
            {
                return new MyAppNavigationRequest<T>(() => IoC.Get<T>(), _shell);
            }
    
            /// <summary>
            /// <see cref="MyApplicationNavigator"/> specific implementation of <see cref="INavigationRequest{T}"/>
            /// </summary>
            /// <typeparam name="T">Type of view model</typeparam>
            private class MyAppNavigationRequest<T> : INavigationRequest<T>
            {
                private readonly Lazy<T> _viemodel;
                private readonly IShell _shell;
    
                public MyAppNavigationRequest(Func<T> viemodelFactory, IShell shell)
                {
                    _viemodel = new Lazy<T>(viemodelFactory);
                    _shell = shell;
                }
    
                public T Screen { get { return _viemodel.Value; } }
                public void Go()
                {
                    _shell.ActivateItem(_viemodel.Value);
                }
            }
        }
