    var friendIds = userConnected.Friends.Select(f=>f.UserId).ToList();
    List<User> users = db.User
      .Where(user => user.Name.Contains(research)
      .Where(user => user.UserId != UserConnected.UserId)
      .Where(user => !friendIds.Contains(user.UserId))
    .ToList();
