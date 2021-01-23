    public class MyRepository : IMyRepository
    {
        public IMyDependency { get; } =
            CallContextServiceLocator.Locator
                                     .ServiceProvider
                                     .GetRequiredService<IMyDependency>();
    }
