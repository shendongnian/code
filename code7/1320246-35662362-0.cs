    public class Singleton1 : ISingleton1
    {
        private readonly ILifetimeScope _lifetimeScope;
        public Singleton1(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public void HandleExternalAddItemMessage(AddItemMessage msg)
        {
            using(var scope = _lifetimeScope.BeginLifetimeScope())
            {
                var dataService = scope.Resolve<IDataService>();
                dataService.AddItem(msg.Item);
            }
        }
    }
