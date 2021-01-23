    itemContainer.items = list1.Concat(list2).Concat(list3)
                        .Distinct()
                        .OrderBy(item => item.Name)
                        .ThenByDescending(item => item.IsSelected)
                        .ToList();
