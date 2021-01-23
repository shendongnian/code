    public SomeService(IUrlHelperFactory urlHelperFactory,
                       IActionContextAccessor actionContextAccessor)
    {
     
        var urlHelper =
            urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
    }
