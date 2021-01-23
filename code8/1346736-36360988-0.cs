    var listings = dbContext.Listings.Select(l => new {
        Id = l.Id,
        User = l.User,
        //add every property you need to show inside your View
        Image = l.Images.FirstOrDefault(i => i.isPrimary)
    });
