    public class LotInfoInject : ConventionInjection
    {
        protected override bool Match(ConventionInfo c)
        {
            return c.SourceProp.Name.StartsWith("io")
                && c.SourceProp.Name == c.TargetProp.Name;
        }
    }
