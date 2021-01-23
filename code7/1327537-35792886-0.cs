    ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver( x =>
                                                                         {
                                                                             var viewName = x.FullName;
                                                                             viewName = viewName.Replace( ".Views.", ".ViewModels." );
                                                                             var viewAssemblyName = x.GetTypeInfo().Assembly.FullName;
                                                                             var suffix = viewName.EndsWith( "View" ) ? "Model" : "ViewModel";
                                                                             var viewModelName = string.Format( CultureInfo.InvariantCulture, "{0}{1}, {2}", viewName, suffix, viewAssemblyName );
                                                                             return Type.GetType( viewModelName );
                                                                         } );
    ViewModelLocationProvider.SetDefaultViewModelFactory( type => Container.Resolve( type ) );
