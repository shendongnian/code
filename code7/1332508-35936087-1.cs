    public static MvcHtmlString DisplayNameFor(this HtmlHelper html, 
                                               Type modelType, string expression)
    {
        var metadata = ModelMetadataProviders.Current
                          .GetMetadataForProperty(null, modelType, expression);
        return MvcHtmlString.Create(metadata.GetDisplayName());
    }
