    internal class Foo
    {
        private static readonly MethodInfo DoStuffToRepositoryForMethod =
            typeof(Foo).GetMethod(
                "DoStuffToRepositoryFor",
                BindingFlags.Instance | BindingFlags.NonPublic);
        private readonly IResolutionRoot resolutionRoot;
        public Foo(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }
        public void DoStuffToRepositories(params Type[] entityTypes)
        {
            foreach (Type entityType in entityTypes)
            {
                MethodInfo doStuffMethod = DoStuffToRepositoryForMethod
                    .MakeGenericMethod(entityType);
                doStuffMethod.Invoke(this, new object[0]);
            }
        }
        private void DoStuffToRepositoryFor<T>()
        {
            var repository = this.resolutionRoot.Get<IRepository<T>>();
            repository.DoSomething();
        }
    }
