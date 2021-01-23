    public class AssociatedMetadataConfig
    {
        public static void RegisterMetadatas()
        {
            RegisterPairOfTypes(typeof(Issue), typeof(IssueMetadata));
            RegisterPairOfTypes(typeof(IssueViewModel), typeof(IssueMetadata));
        }
        private static void RegisterPairOfTypes(Type mainType, Type buddyType)
        {
            AssociatedMetadataTypeTypeDescriptionProvider typeDescriptionProvider 
              = new AssociatedMetadataTypeTypeDescriptionProvider(mainType, buddyType);
            TypeDescriptor.AddProviderTransparent(typeDescriptionProvider, mainType);
        }
    }
