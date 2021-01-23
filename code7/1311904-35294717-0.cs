    class MyAutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool IsDiscriminated(Type type)
        {
            return false; // or whatever classes it should discriminate instead of table per type
        }
    }
