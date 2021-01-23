    [...update journal...]
    
    // Create and set the view model based on the navigation context
    var viewAsDependencyObject = view as DependencyObject;
    if (viewAsDependencyObject != null)
    {
        var createViewModelOnNavigateTo = ViewModelLocator.GetCreateViewModelOnNavigateTo( viewAsDependencyObject );
        if (createViewModelOnNavigateTo)
            ViewModelLocator.Bind( view, _viewModelProvider.CreateViewModel( viewAsDependencyObject, navigationContext ) );
    }
    
    [...inform view...]
