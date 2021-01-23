    private class ReturnUsers
    {
        public string UserName { get; set; }
        public string UserPix { get; set; }
        public string ConnectionId { get; set; }
        public string RoomName { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public User GetUserAndConnections(string username, string roomname)
    {
    var sql = @"SELECT  Users.UserName, Users.UserPix,
                Connections.ConnectionId, Connections.RoomName, Connections.DateCreated
                FROM      Users CROSS JOIN  Connections
                WHERE     (Users.UserName = @p0) AND (Connections.RoomName = @p1)";
    var values = _context.Database.SqlQuery<ReturnUsers>(sql, username, roomName).ToList();
    var first = values.FirstOrDefault();
    User user = null;
    if (first != null)
    {
        user = new User(first.UserName, first.UserPix);
        foreach (ReturnUsers value in values)
        {
            user.AddConnection(value.ConnectionId, value.RoomName);
        }
    }
    return user;
    }
