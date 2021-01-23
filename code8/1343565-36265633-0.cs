    k.RegisterType<Scoped<UserScope>>().AsSelf().WithParameter("childTag", "User");
    public class Scoped<T>
    {
        public Scoped(ILifetimeScope scope, object childTag)
        {
            Value = scope.BeginLifetimeScope(childTag).Resolve<T>();
        }
        public T Value { get; }
    }
    public class UserRepository
    {
        Func<Scoped<UserScope>> _factory;
        public UserRepository(Func<Scoped<UserScope>> factory)
        {
            _factory = factory;
        }
    }
