    db.Categories
      .Where(x=> x.ID == category.ID)
      .Select(x=> new {
        Category = x,
        Section = db.Sections.FirstOrDefault(y => y.ID == x.SectionID),
        SubCategories = db.Categories.Where(y=> y.ParentCategoryID == x.ID)
      }).FirstOrDefault();
