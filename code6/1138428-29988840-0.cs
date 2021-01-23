    IEnumerable<SelectListItem> ldidList = _db.TrafficHits
                                              .GroupBy(t => t.Id)
                                              .Select(g => g.First())
                                              .Select(c => new SelectListItem
                                              {
                                                 Value = c.Id.ToString(),
                                                 Text = c.ldid
                                             });
