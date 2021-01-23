    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(
        Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>))
    }
    );
    public class Repository<T> : IRepository<T> where T : class, IEntity
	{
    ...
    }
