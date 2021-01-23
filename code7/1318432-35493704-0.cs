    _db.Routes.Select(r => new RouteExtentSearchProjection {
                        GeoPathSmall = r.GeoPathSmall,
                        ID = r.ID,
                        IsPublished = r.IsPublished,
                        Sort = r.Sort,
                        Title = r.Title })
                        .ToList());
