        public class DependencyComponentSelector : ITypedFactoryComponentSelector
    {
        public DependencyComponentSelector(IKernel kernel)
        {
            Kernel = kernel;
        }
        public Func<IKernelInternal, IReleasePolicy, object> SelectComponent(MethodInfo method, Type type, object[] arguments)
        {
            return (k, r) =>
            {
                return from dependency in k.ResolveAll<IDependency>()
                       where dependency.Argument == int.Parse(arguments[0].ToString())
                       select dependency;
            };
        }
        public IKernel Kernel { get; set; }
    }
