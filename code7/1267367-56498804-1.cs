                        var defaultFavorite = _context.SysUserDisplayFavorites
                        .Where(x => x.UserId.SqlCompare(displayFavorite.UserId))
                        .Where(x => x.ModuleCode.SqlCompare(displayFavorite.ModuleCode))
                        .Where(x => x.ActivityCode.SqlCompare(displayFavorite.ActivityCode))
                        .Where(x => x.ActivityItemCode.SqlCompare(displayFavorite.ActivityItemCode))
                        .Where(x => x.IsDefault);
