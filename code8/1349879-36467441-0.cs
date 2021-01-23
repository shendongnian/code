    var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
    var products = contentRepository.GetChildren<MyProduct>(Model.ContentLink);
    
    foreach(var product in products)
    {
        //Do what you want.
    }
