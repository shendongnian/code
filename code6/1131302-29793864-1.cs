    // example class
    public class SampleClass2
    {
        public IHubContext Context { get; set; }
    }
    // registration for this case
    builder.RegisterType<SampleClass2>()
        .PropertiesAutowired()
        .OnActivated(e => e.Instance.Context = e.Context.ResolveNamed<IHubContext>("MyHub"));
