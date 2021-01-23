    public class ExtendedLinqToHqlGeneratorsRegistry :
        DefaultLinqToHqlGeneratorsRegistry
    {
        public ExtendedLinqToHqlGeneratorsRegistry()
            : base()
        {
            // Non explicitly declared types support, through inspection.
            this.RegisterGenerator(new AsNullableGenerator());
            // Explicitly declared types support.
            this.Merge(new AsNullableGenerator());
        }
    }
