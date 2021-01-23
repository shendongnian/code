    // example class 
    public class SampleClass {
        public SampleClass(IHubContext context) { }
    }
    // and registration for this class
    builder.RegisterType<SampleClass>()
        .WithParameter(new ResolvedParameter((pi, ctx) =>
        {
            // only apply this to parameters of IHubContext type
            return pi.ParameterType == typeof(IHubContext);
        }, (pi, ctx) =>
        {
            // resolve context
            return ctx.ResolveNamed<IHubContext>("SampleHub");
        }));
