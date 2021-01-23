    public class ExtendedLinqToHqlGeneratorsRegistry :
        DefaultLinqToHqlGeneratorsRegistry
    {
        public ExtendedLinqToHqlGeneratorsRegistry()
            : base()
        {
            this.Merge(new AsNullableGenerator());
        }
    }
