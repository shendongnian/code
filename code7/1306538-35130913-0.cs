    var userPoints = Context.Users.Select(user => new
        {
            Points = user.UserPoints.Sum(p => p.Point.Value),
            User = user
        })
        .Where(user => user.Points != 0 || user.User.UserId == userId);
    
    var users = userPoints.OrderByDescending(user => user.Points)
       .Select(model => new UserScoreModel
        {
            Points = model.Points,
            Country = model.User.Country,
            FacebookId = model.User.FacebookUserId,
            Name = model.User.FirstName + " " + model.User.LastName,
            Position = 1 + userPoints.Count(up => up.Points < model.Points),
            UserId = model.User.UserId,
        });
