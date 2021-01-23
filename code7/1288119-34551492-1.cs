    ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(
                viewType =>
                    {
                        // The default prism view model type resolver as Priority 
                        Type viewModelType = this.GetDefaultViewModelTypeFromViewType(viewType);
                        if (viewModelType != null)
                        {
                            return viewModelType;
                        }
                        // IF no view model found by the default prism view model resolver
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
                                        }).Distinct() ;
                        // Get the type where the delegate is applied
                        var customConvention = new Func<Type, bool>(
                            (Type t) =>
                                {
                                    const string ViewModelSuffix = "ViewModel";
                                    var isTypeWithViewModelSuffix = t.Name.EndsWith(ViewModelSuffix);
                                    return (isTypeWithViewModelSuffix)
                                           && ((viewType.Name.EndsWith("View") && viewType.Name + "Model" == t.Name)
                                               || (viewType.Name + "ViewModel" == t.Name));
                                });
                        var resolvedViewModelType = bindableBases.FirstOrDefault(customConvention);
                        return resolvedViewModelType;
                    });
