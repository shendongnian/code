    internal class EntityFactory
    {
        public EntityFactory( IUnityContainer container )
        {
            _container = container;
        }
        public IEntity CreateEntity( string processType )
        {
            return _container.Resolve<IEntity>( processType, new ParameterOverride( "repo", _container.Resolve<IRepo>( processType ) ) );
        }
        private readonly IUnityContainer _container;
    }
