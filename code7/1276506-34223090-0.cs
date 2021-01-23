    public HandlerAttribute() :
            this(DependencyResolver.Current.GetService<IDetailsProvider>()) { }
    public HandlerAttribute(IDetailsProvider detailsProvider)
    {
        _detailsProvider = detailsProvider;
    }
