    var de = _context.DamageEvents.Where(dm => dm.StatusID == statusId)
                        .GroupBy(dm => new {dm.ClientId, dm.Client.ClientName, dm.SiteId, dm.Site.Name, dm.SiteObjectId})
                        .Select(g => new
                        {
                            g.Key.ClientId,
                            g.Key.ClientName,
                            g.Key.SiteId,
                            g.Key.Name,
                            g.Key.SiteObjectId,
                            icon = g.Select(i => i.SiteObject.ObjectModel.ObjectType.Icon).FirstOrDefault()
                        });
