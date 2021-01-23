    public List<Point> GetAllUsers() 
    {
        var data = new DataClasses1DataContext();
        var userIds = data.Tabs.Where(t => t.u1ID == 1).Select(t => t.u2ID).ToList();
        var users = data.Users.Where(u => userIds.Contains(u.Id)).ToList();
        var locations = users.Select(u => new Point { Lat = u.usrLat, Lon = u.usrLong }).ToList();
        return locations;
    } 
