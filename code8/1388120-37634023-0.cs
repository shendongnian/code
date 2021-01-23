    var query = _dbContext.Orders
                                    .ToList()
                                    // Group them by what you want to "distint" on
                                    .GroupBy(item=>item.ShipCity)
                                    // For each of those groups grab the first item, we just faked a distinct)
                                    .Select(item=>item.First())
                                    .Select(x => new SelectListItem
                                    {
                                        Text = x.OrderID.ToString(),
                                        Value = x.ShipCity
                                    })
                                    .OrderBy(y => y.Value)
                                    .Distinct();
