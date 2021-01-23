    // all the NavigateCommandFor extensions also provide the ability to inject the navigate command itself (the default Navigate, or NavigateAndReset), 
    // the dependency resolver (still defaults to Locator.Current), and the type resolution contract
    public static partial class ExtensionMethods
    {
        // simple extension to inline the subscription
        public static T SubscribeToCommand<T>(this T This)
            where T : IReactiveCommand
        {
            This.CanExecuteObservable.Subscribe();
            return This;
        }
        // this was my first attempt without actually analyzing the current NavigateCommandFor source
        public static IReactiveCommand<object> NavigateCommandFor1<T>(this RoutingState This, IReactiveCommand<object> navigationCommand = null, IDependencyResolver dependencyResolver = null, string contract = null)
            where T : IRoutableViewModel
        {
            navigationCommand = navigationCommand ?? This.Navigate;
            var ret = ReactiveCommand.CreateAsyncObservable(navigationCommand.CanExecuteObservable, _ => navigationCommand.ExecuteAsync((dependencyResolver ?? Locator.Current).GetService<T>(contract)));
            return ret.SubscribeToCommand();
        }
        // After looking at the NavigateCommandFor source, this is minimalistic adaptation 
        // except ajusting the return value to be the generic interface with an object type param
        public static IReactiveCommand<object> NavigateCommandFor2<T>(this RoutingState This, IReactiveCommand<object> navigationCommand = null, IDependencyResolver dependencyResolver = null, string contract = null)
            where T : IRoutableViewModel
        {
            navigationCommand = navigationCommand ?? This.Navigate;
            var ret = new ReactiveCommand<object>(navigationCommand.CanExecuteObservable, x => Observable.Return(x));
            ret.Select(_ => (dependencyResolver ?? Locator.Current).GetService<T>(contract)).InvokeCommand(navigationCommand);
            return ret.SubscribeToCommand();
        }
        // My attempt to optimize the return value to be strongly typed
        // I'm not sure if this has any implications
        public static IReactiveCommand<T> NavigateCommandFor3<T>(this RoutingState This, IReactiveCommand<object> navigationCommand = null, IDependencyResolver dependencyResolver = null, string contract = null)
            where T : IRoutableViewModel
        {
            navigationCommand = navigationCommand ?? This.Navigate;
            var ret = new ReactiveCommand<T>(navigationCommand.CanExecuteObservable, _ => Observable.Return((dependencyResolver ?? Locator.Current).GetService<T>(contract)));
            
            ret.InvokeCommand(navigationCommand);
            
            return ret.SubscribeToCommand();
        }
        // The original source allows for un-registered view models to be new()'d
        // this extension provides that same ability, but again with a strongly typed return value
        public static IReactiveCommand<T> NavigateCommandFor4<T>(this RoutingState This, IReactiveCommand<object> navigationCommand = null, IDependencyResolver dependencyResolver = null, string contract = null)
            where T : IRoutableViewModel, new()
        {
            navigationCommand = navigationCommand ?? This.Navigate;
            var ret = new ReactiveCommand<T>(navigationCommand.CanExecuteObservable, _ => Observable.Return((T)((IRoutableViewModel)(dependencyResolver ?? Locator.Current).GetService<T>(contract) ?? new T())));
            ret.InvokeCommand(navigationCommand);
            return ret.SubscribeToCommand();
        }
    }
