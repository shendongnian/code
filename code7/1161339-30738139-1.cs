    public class MyConvention : DefaultConventionScanner
    {
        public override void Process(Type type, Registry registry)
        {
            base.Process(type, registry);
            
            // here we shold do some evaluation what to map
            // for example
            // just classes wich are not abstract 
            var skipType = type.IsAbstract
                           || !type.IsClass;
            if (skipType)
            {
                return;
            }
            // here we do the magic
            // register each type with transient Lifecycle
            registry.For(type)
                .LifecycleIs(new StructureMap.Pipeline.TransientLifecycle())
                .Use(type);
        }
    }
