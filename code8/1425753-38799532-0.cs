    using System.Composition;
    ...
    [ImportingConstructor]
    public Logger(ISetting settings)
    {
        this.settings = settings;
    }
