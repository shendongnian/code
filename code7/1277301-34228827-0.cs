    class SomeClassThatConsumesOneOfYourImplementations
    {
        public SomeClassThatConsumesOneOfYourImplementations(
            [Named("DbGeoContext")] IDataContextAsync context)
        {
            // Constructor logic...
        }
    }
