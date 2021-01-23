    foreach (var richContentCategory in categories)
    {
        if (list.Contains(richContentCategory.WordpressName))
        {
            item.Categories.Add(new RichContentCategory { Id = richContentCategory.Id});
        }
    }
