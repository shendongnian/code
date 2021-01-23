    var sales = this.Context.Sales
        .GroupBy(x => x.User) // ApplicationUser
        .Select(x =>
        {
            UserId = x.Key.Id,
            Username = x.Key.UserName,
            SalesTotal = x.Sum(y => y.Price)
        })
        .OrderByDescending(x => x.SalesTotal)
        .AsEnumerable()
        .Select((x, index) => new UserSale
        {
            UserId = x.UserId,
            Username = x.Username,
            SalesTotal = x.SalesTotal,
            Rank = index,
        });
