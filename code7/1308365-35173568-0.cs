    // Aspect class
    [Serializable]
    public class ProviderAspect : TypeLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            // ...
        }
    }
    // Apply to a single type
    [ProviderAspect]
    public class TargetClass : IReportBuilder
    {
        public void Execute()
        {
            // ...
        }
    }
    // Apply to many types
    [assembly: ProviderAspect (AttributeTargetTypes="OurCompany.OurApplication.Reports.*")]
