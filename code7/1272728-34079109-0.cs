    public static IHtmlString RenderSectionEx(this WebPageBase webPage, 
                                              string name, 
                                              Func<IHtmlString> defaultContentMethod)
    {
        if (webPage.IsSectionDefined(name))
            return webPage.RenderSection(name);
        return defaultContentMethod();
    }
