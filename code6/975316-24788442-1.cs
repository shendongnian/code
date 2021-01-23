    public User GetUserAndConnections(string username, string roomname)
    {
        var user = _context.Users.Find(username);
        if (user != null)
        {
            var connections =
                _context.Users.Where(u => u.UserName == username)
                    .SelectMany(x => x.Connections.Where(p => p.RoomName == roomName))
                    .ToList();
            user.AddExistingConnections(connections);
        }
        return user;
    }
