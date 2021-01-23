    public class CustomResolver : IValueResolver
    {
        public ResolutionResult Resolve(ResolutionResult source)
        {
            return source.New( Convert.ChangeType((source.Context.SourceValue as DataRow)[source.Context.MemberName], source.Context.DestinationType));
        }
    }
