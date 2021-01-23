    from z in SelectFeatures
    order z by z.FeaturePackId into g
    select new FeaturePack { 
    						FeaturePackId = g.Key, 
    						Features = g}
    public class FeaturePack
    {
        public int FeaturePackId { get; set; }
        public IEnumerable<Feature> Features { get; set; }
    }
