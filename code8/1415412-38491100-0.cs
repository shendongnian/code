      if (!string.IsNullOrEmpty(SelectedCategoriesIds))
      {
               List<Category> stringList = new List<Category>();
               stringList.AddRange(
                    SelectedCategoriesIds.Split(',')
                         .Select(i => new Category() { CategoryId = int.Parse(i) }));
                model.Categories = stringList.AsEnumerable();
     }
     else
     {
          //set the property to an empty arrary
          model.Categories = new Category[]{};
     }
