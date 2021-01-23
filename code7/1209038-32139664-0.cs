    public class FooFactory : IFooFactory
    {
        private readonly Func<FooSettings, Foo> creationFunc;
        private readonly ISettingsProvider settingsProvider;
        public FooFactory(Func<FooSettings, Foo> creationFunc, ISettingsProvider settingsProvider)
        {
            if (creationFunc == null) throw new ArgumentNullException("creationFunc");
            if (settingsProvider == null) throw new ArgumentNullException("settingsProvider");
            this.creationFunc = creationFunc;
            this.settingsProvider = settingsProvider;
        }
        public Foo CreateFoo()
        { 
            var providerSettings = settingsProvider.GetSettings("fooSettings");
            var fooSettings = new FooSettings(providerSettings[0], providerSettings[1]);
            return creationFunc(fooSettings);
        }
    }
