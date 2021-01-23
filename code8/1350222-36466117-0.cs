         List<Item> InventoryList = new List<Item>()
            {
                new Item { date = DateTime.Now, Description = "Orange", Price = 29.99 },
                new Item { date = DateTime.Now, Description = "Apple", Price = 99.99 },
                new Item { date = DateTime.Now, Description = "Grape", Price = 29.99 }
            };
            List<Item> PurchaseList = new List<Item>()
            {                
                new Item { date = DateTime.Now, Description = "Pear", Price = 29.99 },
                new Item { date = DateTime.Now, Description = "Orange", Price = 49.99 },
                new Item { date = DateTime.Now, Description = "Peach", Price = 29.99 }
            };
            foreach (var item in PurchaseList)
            {
                var match = InventoryList.Where(t => t.Description == item.Description).FirstOrDefault();
                if (match != null)
                    item.Price = match.Price;
            }
