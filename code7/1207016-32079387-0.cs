    public class RavenRepository<T> : IRepository<T> where T : Entity
    ...
    builder.RegisterGeneric(typeof (RavenRepository<>))
        .AsSelf()
        .AsImplementedInterfaces()
        .InstancePerRequest();
