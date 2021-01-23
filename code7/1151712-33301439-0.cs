    public class StatelessActor2 : Actor, IStatelessActor2
    {
        private ConfiguredContainer _container;
        private IRootElement _rootElement;
        public StatelessActor2()
        {
            _container = new ConfiguredContainer(); //... container is configured in it's constructor
            _rootElement = _container.Resolve<IRootElement>();
        }
        public async Task<string> DoWorkAsync()
        {
            // Working with a RootElement with all dependencies are injected..
            return await Task.FromResult(_rootElement.WorkingWithInjectedStuff());
        }
    }
