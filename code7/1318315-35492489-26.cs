    public class YourLinqToHqlGeneratorsRegistry:
        NHibernate.Linq.Functions.DefaultLinqToHqlGeneratorsRegistry
    {
        public YourLinqToHqlGeneratorsRegistry()
        {
            // using NHibernate.Linq.Functions; required for .Merge() to be found
            // at compile time.
            this.Merge(new ClassGenerator());
        }
    }
