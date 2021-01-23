    using System;
    using System.Collections.Generic;
    using Autofac;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var containerBuilder = new ContainerBuilder();
                // customise your assembly loader for runtime behaviour
                containerBuilder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                    .Where(t => t.BaseType == typeof(DbContext))
                    .As<DbContext>().OnPreparing(eventArgs =>
                    {
                        // depending on which context you are activating you can do use somekind of convention to get the correct connection string
                    });
            
                containerBuilder.RegisterType<MultiContextService>();
                var container = containerBuilder.Build();
                var mcs = container.Resolve<MultiContextService>();
            }
        }
        internal class MultiContextService
        {
            public MultiContextService(IEnumerable<DbContext> allContexts)
            {
                // all contexts are resolved here
            }
        }
        internal abstract class DbContext
        {
        }
        internal class DbContext1 : DbContext
        {
        
        }
        internal class DbContext2 : DbContext
        {
        }
    }
