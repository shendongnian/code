    var licenses = context.LicenseUsers
        .Include(lu => lu.License.Product)
        .Where(lu => lu.User.Id == user.Id)
        .Select(lu => new { lu.License, lu.Product })
        .ToList();
