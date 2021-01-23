    var categories = _richContentCategoryService.GetBySpecification(new RichContentCategorySpecification()
    {
        Take = Int32.MaxValue
    });
    var list = dto.custom_fields.category_type[0];
    foreach (var richContentCategory in categories)
    {
        if (list.Contains(richContentCategory.WordpressName))
        {
            richContentCategory.RichContents.Add(item);
        }
    }
    // Save updated categories somehow, using "_richContentCategoryService" object
    _richContentCategoryService.Save(categories);
