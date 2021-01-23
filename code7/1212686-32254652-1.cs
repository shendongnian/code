    public class ChainMap: ClassMap<Chain>
    {
        public ChainMap()
        {
            // ...
            HasMany(x => x.Steps).Cascade.AllDeleteOrphan().Inverse().Not.LazyLoad();
        }
    }
