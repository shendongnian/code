    public List<Category> GetCategories()
    {
        List<Category> categories;
        using (var db = new MyDb())
        {
            categories= db.Categories.Select(p => new Category
            {
                Id = p.Id,
                Name = p.Name,
                Elements = p.ElementsCategories.Select(ec=>ec.Element)
            }).ToList();
        }
        return categories;
    }
