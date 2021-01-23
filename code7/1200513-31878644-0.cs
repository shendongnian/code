            var list1 = new List<Item>
            {
                new Item { Id = 1, Name = "item1", ItemParentId = 100 },
                new Item { Id = 2, Name = "item2", ItemParentId = 200 },
                new Item { Id = 3, Name = "item3", ItemParentId = 300 },
                new Item { Id = 1, Name = "item4", ItemParentId = 400 }
            };
            var list2 = new List<Item>
            {
                new Item { Id = 0, Name = "item5", ItemParentId = 500 },
                new Item { Id = 0, Name = "item6", ItemParentId = 300 },
                new Item { Id = 0, Name = "item7", ItemParentId = 400 },
            };
            var listMerge = list1.Union(list2.Where(l2 => !list1.Select(l1 => l1.ItemParentId).Contains(l2.ItemParentId))).ToList();
