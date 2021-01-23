    var user = context.Users.Where(u => u.Id == 1).Single();
    var applications = user.Clients
        .SelectMany(c => c.Application)
        .GroupBy(a = a.Id)
        .Select(a => a.First());
