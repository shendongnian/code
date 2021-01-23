    class Program
    {
        private static IContainer container { get; set; }
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DbCtx1>().As<IDbCtx>();
            container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var dbctx = scope.Resolve<IDbCtx>();
                Console.WriteLine(dbctx.GetType());
            }
            builder = new ContainerBuilder();
            builder.RegisterType<DbCtx2>().As<IDbCtx>();
            container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var dbctx = scope.Resolve<IDbCtx>();
                Console.WriteLine(dbctx.GetType());
            }
        }
    }
    interface IDbCtx
    {
         
    }
    class DbCtx1 : IDbCtx { }
    class DbCtx2 : IDbCtx { }
