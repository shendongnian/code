    var usersConnections = context.Users
    .Where(u => u.UserName == userName)
    .Select(u => new
    {
        User = u,
        Connections = u.Connections.Where(c => c.RoomName == roomName)
    });
