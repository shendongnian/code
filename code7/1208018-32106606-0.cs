    vars list = dbContext.UserCategories
      .Where(x => x.DisplayOrder > 0)
      .OrderBy(x => x.UserCategoryType)
      .ThenBy(x => x.DisplayOrder)
      .ToList()
      .Select(uc => new ExtendedSelectListItem()
        {
          HtmlAttribute = "form-control",
          Value = uc.UserCategoryID.ToString(),
          Text = uc.UserCategoryType
        })
      .ToList()
