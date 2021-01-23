    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IProcessorFactory>().ToMethod(context => new ProcessorFactoryA(() => context.Kernel.Get<ProcessorX>()));
            Bind<IProcessorFactory>().ToMethod(context => new ProcessorFactoryB(() => context.Kernel.Get<ProcessorY>()));
            Bind<IProcessorFactory>().ToMethod(context => new ProcessorFactoryC(() => context.Kernel.Get<ProcessorZ>()));
            // Note that item type D is handled by processor X
            Bind<IProcessorFactory>().ToMethod(context => new ProcessorFactoryD(() => context.Kernel.Get<ProcessorX>()));
        }
    }
