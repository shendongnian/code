    // register your services as per Nico's answer
    builder.Register...
    // register a factory with Autofac
    builder.Register<Func<Type, IRepository>>(x => {
        var context = x.Resolve<IComponentContext>();
        return y => { 
            return (IRepository) context.Resolve(y);
        };
    });
    // use the factory in your Unit of Work
    class UnitOfWork
    {
        readonly Func<Type, IRepository> _factory;
        public void SomeMethod(object o)
        {
            var repository = _factory(o.GetType());
            repository.DoSomething(o);
        }
    }
