    public class MvvmTypeLocator: IMvvmTypeLocator
    {
        private AggregateCatalog AggregateCatalog { get; set; }
        public MvvmTypeLocator(AggregateCatalog aggregateCatalog)
        {
            this.AggregateCatalog = aggregateCatalog;
        }
        public Type GetViewModelTypeFromViewType(Type sourceType)
        {
            // The default prism view model type resolver as Priority 
            Type targetType = this.GetDefaultViewModelTypeFromViewType(sourceType);
            if (targetType != null)
            {
                return targetType;
            }
            // Get assembly catalogs
            var assemblyCatalogs = this.AggregateCatalog.Catalogs.Where(c => c is AssemblyCatalog);
            // Get all exported types inherit from BindableBase prism class
            var bindableBases =
                assemblyCatalogs.Select(
                    c =>
                    ((AssemblyCatalog)c).Assembly.GetExportedTypes()
                        .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(BindableBase)))
                        .Select(t => t)).SelectMany(b =>
                        {
                            var types = b as IList<Type> ?? b.ToList();
                            return types;
                        }).Distinct();
            // Get the type where the delegate is applied
            var customConvention = new Func<Type, bool>(
                (Type t) =>
                {
                    const string TargetTypeSuffix = "ViewModel";
                    var isTypeWithTargetTypeSuffix = t.Name.EndsWith(TargetTypeSuffix);
                    return (isTypeWithTargetTypeSuffix)
                           && ((sourceType.Name.EndsWith("View") && sourceType.Name + "Model" == t.Name)
                               || (sourceType.Name + "ViewModel" == t.Name));
                });
            var resolvedTargetType = bindableBases.FirstOrDefault(customConvention);
            return resolvedTargetType;
        }
        public Type GetViewTypeFromViewModelType(Type sourceType)
        { 
            // Get assembly catalogs
            var assemblyCatalogs = this.AggregateCatalog.Catalogs.Where(c => c is AssemblyCatalog);
            // Get all exported types inherit from BindableBase prism class
            var bindableBases =
                assemblyCatalogs.Select(
                    c =>
                    ((AssemblyCatalog)c).Assembly.GetExportedTypes()
                        .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(IView)))
                        .Select(t => t)).SelectMany(b =>
                        {
                            var types = b as IList<Type> ?? b.ToList();
                            return types;
                        }).Distinct();
            // Get the type where the delegate is applied
            var customConvention = new Func<Type, bool>(
                (Type t) =>
                {
                    const string SourceTypeSuffix = "ViewModel";
                    var isTypeWithSourceTypeSuffix = t.Name.EndsWith(SourceTypeSuffix);
                    return (isTypeWithSourceTypeSuffix)
                           && ((sourceType.Name.EndsWith("View") && t.Name + "Model" == sourceType.Name)
                               || (t.Name + "ViewModel" == sourceType.Name));
                });
            var resolvedTargetType = bindableBases.FirstOrDefault(customConvention);
            return resolvedTargetType;
        }
        public Type GetViewTypeFromViewName(string viewName)
        {
            // Get assembly catalogs
            var assemblyCatalogs = this.AggregateCatalog.Catalogs.Where(c => c is AssemblyCatalog);
            // Get all exported types inherit from BindableBase prism class
            var bindableBases =
                assemblyCatalogs.Select(
                    c =>
                    ((AssemblyCatalog)c).Assembly.GetExportedTypes()
                        .Where(t => !t.IsAbstract && typeof(IView).IsAssignableFrom(t) && t.Name.StartsWith(viewName))
                        .Select(t => t)).SelectMany(b =>
                        {
                            var types = b as IList<Type> ?? b.ToList();
                            return types;
                        }).Distinct();
            // Get the type where the delegate is applied
            var customConvention = new Func<Type, bool>(
                (Type t) =>
                    {
                        return t.Name.EndsWith("View");
                    });
            var resolvedTargetType = bindableBases.FirstOrDefault(customConvention);
            return resolvedTargetType;
        }
        private Type GetDefaultViewModelTypeFromViewType(Type viewType)
        {
            var viewName = viewType.FullName;
            viewName = viewName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var suffix = viewName.EndsWith("View") ? "Model" : "ViewModel";
            var viewModelName = String.Format(
                CultureInfo.InvariantCulture,
                "{0}{1}, {2}",
                viewName,
                suffix,
                viewAssemblyName);
            return Type.GetType(viewModelName);
        }
    }
