    var temp = _context
                 .FavouriteVol
                 .AsEnumerable()
                 .Join(
                    _context.Favourites
                          .Where(u => u.userId == userId)
                          .AsEnumerable(),
                    fv => new { fv.EntityId, fv.CountryId, fv.EType },
                    f => new { f.EntityId, f.CountryId, f.EType },
                    (fv, f) => new { FavouriteVol = fv, Favourites = f }
                 )
                 .ToList();
