    public class ViewModulesCatalog : FilteredCatalog
    {
        public ViewModulesCatalog(ComposablePartCatalog inner, IPermissionsProvider permissionsProvider)
            : base(inner, part => part.ExportDefinitions.All(def => permissionsProvider.IsAllowed(def)))
    }
