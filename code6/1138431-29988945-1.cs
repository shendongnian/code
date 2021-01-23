    IEnumerable<SelectListItem> ldidList = _db.TrafficHits.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.ldid
                }).Distinct(new SelectListItemComparer());
