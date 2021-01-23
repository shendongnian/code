    CategoryDto =  x.Post.Category.CategoriesI18N
                    .Where(c => c.LanguageCode == "en")
                    .Select(c => new CategoryDto {
                         Id = x.Category.Id,
                         Name = c.Name,
                         Slug = c.Slug
                     }).FirstOrDefault()       
