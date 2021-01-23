    var temp = _context
               .FavouriteVol
               .Join(_context.Favourites,
                        fv => new { fv.EntityId, fv.EType },
                        f => new { f.EntityId, f.EType },
                            (fv, f) => new { Favourites = f, FavouriteVol = fv })
                            .Where(u => u.Favourites.userId == userId
                                     && u.Favourites.CountryId == u.FavouriteVol.CountryId)
                            .Select(f => f.Favourites != null)
                            .ToList();
