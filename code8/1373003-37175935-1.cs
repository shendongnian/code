    var items = from i in context.ItemModels
                    .Include(i => i.Manufacturer)
                    .Include(i => i.SubCategory)
                    .Include(i => i.SubCategory.Category)
                            select i;
    
                // Apply filter if search query was entered
                if (!String.IsNullOrEmpty(searchString))
                {
                    string[] searchWords = searchString.Split(' ');
    
                    foreach (var word in searchWords)
                    {
                        items = items.Where(s => s.Description.Contains(word) ||
                                     s.SubCategory.Category.CategoryName.Contains(word) || 
                                     s.SubCategory.SubCategoryName.Contains(word) ||
                                     s.Manufacturer.Name.Contains(word) ||
                                     s.ModelNum.Contains(word)
                                     );
                    }
                }
                return items;
