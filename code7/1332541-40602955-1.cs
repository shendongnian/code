    public class JobsearcherTraitDiscoverer : ITraitDiscoverer
    {
        public const string VALUE = "Jobsearcher";
    
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            yield return new KeyValuePair<string, string>(CategoryDiscoverer.KEY, VALUE);
        }
    }
    
    [TraitDiscoverer("XunitCategoriesSample.Traits.JobsearcherTraitDiscoverer", "XunitCategoriesSample")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class JobsearcherTraitAttribute : Attribute, ITraitAttribute
    {
        public JobsearcherTraitAttribute()
        {
        }
    }
