    internal class EntityFactory
    {
        public EntityFactory( IUnityContainer container )
        {
            _container = container;
        }
        public IEntity CreateEntity( string processType )
        {
            return _container.Resolve<IEntity>( processType );
        }
        private readonly IUnityContainer _container;
    }
