    public static IHtmlString RenderSectionEx(this WebPageBase webPage, 
                                              string name, 
                                              string defaultContent)
    {
        if (webPage.IsSectionDefined(name))
            return webPage.RenderSection(name);
        return defaultContent;
    }
