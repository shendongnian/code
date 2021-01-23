            var categoryDictionary = All_Items
                                        .GroupBy(i => i.Category)
                                        .ToDictionary(
                                            g => g.Key, 
                                            g => g.Select(i => i.StartDate));
            var defaultDate = DateTime.Parse("2099-12-31");
            foreach (var item in All_Items)
            {
                var nextDateInCategory = categoryDictionary[item.Category]
                                            .Where(i => i > item.StartDate)
                                            .OrderBy(i => i)
                                            .FirstOrDefault();
                item.EndDate =
                    nextDateInCategory != default(DateTime)
                        ? nextDateInCategory.AddDays(-1) 
                        : defaultDate;
            }
