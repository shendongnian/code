    var seller = repo.Query()
                     .Select(x => new
                        {
                            Seller = x,
                            InventoryItems = (x.InventoryItems
                                              .Select(y => new
                            {
                                InventoryItem = y,
                                SiteInventoryItems = y.SiteInventoryItems
                                                      .Where(z => z.Site == SiteType.Amazon)
                            }).Where(x => x.SiteInventoryItems.Any())
                        }).Where(x => x.SiteInventoryItems.Any())
                 ).First();
