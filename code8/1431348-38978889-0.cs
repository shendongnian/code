            var categoryDictionary = All_Items
                                        .GroupBy(i => i.Category)
                                        .ToDictionary(
                                            g => g.Key, 
                                            g => g.Max(i => i.StartDate));
            var defaultDate = DateTime.Parse("2099-12-31");
            foreach (var item in All_Items)
            {
                var maxDateInCategory = categoryDictionary[item.Category];
                item.EndDate = 
                    item.StartDate < maxDateInCategory
                        ? maxDateInCategory.AddDays(-1) 
                        : defaultDate;
            }
