    private List<SummaryRootEntity> search(int contentId,SearchModel query, bool includeTypeGroupFilters = true)
    {
          Dictionary<string, object> dic = PrepareQueryValues(query);
          
          searchmodelDto.shops = (CastToProperType)dic["ShopsList"];
          var filteredArticles = _articleService.Search(
          contentId,
          query,
          (CastToProperType)dic["SearchBounds"],
          (CastToProperType)dic["SearchProfileGroups"],
          (CastToProperType)dic["InactiveForDays"],
          includeTypeGroupFilters);
          // apply ordering
          var result = filteredArticles.ApplyOrdering(query.ForSaleOrRent, query.OrderBy, query.OrderDescending).ToList();
          return result;
          
    }
