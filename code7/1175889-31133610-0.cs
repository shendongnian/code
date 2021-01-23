     Expression<Func<SearchResultItem, bool>> predicate = PredicateBuilder.True<SearchResultItem>();
                predicate = predicate.Or(p => p.TemplateName.Equals("News"));
                predicate = predicate.Or(p => p.TemplateName.Equals("Page"));
        
                IEnumerable<SearchResultItem> results = _searchContext
                    .GetQueryable<SearchResultItem>()
                    .Where(predicate);
