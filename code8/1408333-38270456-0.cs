    var favorites = _context.Favorites.OrderByDescending(f => f.FavDate)
        .Join(_context.Items,
            fav => new { fav.ItemId, UserId = fav.UserVoterId },
            item => new { ItemId = item.Id, UserId = profileId },
            (fav, item) => item)
        .Skip(pageIndex * pageSize)
        .Take(pageSize)
        .ToList();
