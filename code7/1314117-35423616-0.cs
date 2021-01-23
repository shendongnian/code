    using (var context = ContentSearchManager.GetIndex(Search.MasterIndex).CreateSearchContext())
            {
                IQueryable<SearchResultItem> query = context.GetQueryable<SearchResultItem>();
                var computedLanguage = Sitecore.Context.Language.CultureInfo.Name.Replace("-", String.Empty);
                SearchResults<SearchResultItem> results = null;
                query = query.Where(x => x.TemplateId == new ID("{659B67C6-4810-4A22-B9E8-9463005113D6}"));
 
                results = query.GetResults();
    }
