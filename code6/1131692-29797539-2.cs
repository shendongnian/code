    var temp = _context
                 .FavouriteVol
                 .Join(
                    _context.Favourites
                          .Where(u => u.userId == userId),
                    fv => new { fv.EntityId, fv.CountryId, fv.EType },
                    f => new { f.EntityId, f.CountryId, f.EType },
                    (fv, f) => new { 
                       EntityId = fv.EntityId, 
                       CountryId = fv.CountryId, 
                       EType = fv.EType, 
                       //<other fv properties>, 
                       UserId = f.UserId, 
                       //<other f properties>  
                    }
                 )
                 .ToList();
