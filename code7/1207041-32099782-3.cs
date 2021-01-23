    var seller = repo.Query()
            .Select(x => new
            {
                Seller = x,
                InventoryItems = x.InventoryItems.Select(y => new
                {
                    InventoryItem = y,
                    SiteInventoryItems = y.SiteInventoryItems.Where(z => z.Site == SiteType.Amazon)
                }).Where(y => y.SiteInventoryItems.Any())
            }).Where(x => x.Seller.Id == 14).First();
