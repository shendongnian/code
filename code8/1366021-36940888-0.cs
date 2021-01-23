    public class ExampleResolver: ValueResolver<ExampleObject, List<ExampleObject>>
    {
        protected override List<ExampleObject> ResolveCore(ExampleObject source)
        {
            return new List<ExampleObject>() { source };
        }
    }
