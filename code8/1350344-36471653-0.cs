    public class CompositionRoot
    {
        public static Action<IContainer> OverrideContainer = c => { };
        
        internal static IContainer CreateContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();
            /// etc. etc.
            var container = builder.Build();
            OverrideContainer(container);
            return container;
        }
    }
