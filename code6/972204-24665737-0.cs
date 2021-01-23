    public class CustomResolver : IValueResolver
    {
        public ResolutionResult Resolve(ResolutionResult source)
        {
            return source.New((source.Context.SourceValue as DataRow)[source.Context.MemberName]);
        }
    }
