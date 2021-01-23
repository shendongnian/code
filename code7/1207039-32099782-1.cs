    var seller = repo.Query()
                     .Select(x => new
                        {
                            Seller = x,
                            InventoryItems = x.InventoryItems,
                            SiteInventoryItems = x.InventoryItems
                                                  .Select(y => new
                            {
                                InventoryItem = y,
                                SiteInventoryItems = y.SiteInventoryItems
                                                      .Where(z => z.Site == SiteType.Amazon)
                            })
                        }).Where(x => x.Seller.SellerId == 14
                                   && x.SiteInventoryItems
                                       .Any(y => y.SiteInventoryItems.Any()) // added condition
                                ).First();
