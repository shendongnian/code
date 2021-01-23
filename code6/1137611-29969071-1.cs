    var index = ContentSearchManager.GetIndex("sitecore_web_index");
    using (var context = index.CreateSearchContext())
    {
        var queryCalls = context.GetQueryable<TaggedItem>()
                .Where(item => item.TemplateName == callTemplateName)
                .Where(item.Path.StartsWith(callStartingPath))
                .Where(item.Language == Sitecore.Context.Language.Name)
                .Where(item.AppliedThemes.Contains(themeID));
        //...
    }
