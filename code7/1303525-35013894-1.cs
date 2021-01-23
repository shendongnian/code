    var users = new List<Users>();
    foreach (var u in allEvent.AttendingUsers.Split(',').ToList())
    {
        users.Add(new Users
        {
            Id = Convert.ToInt64(u)
        });
    }
    
    allEvent.Users = users;
