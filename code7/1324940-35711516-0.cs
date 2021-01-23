    Users = new List<User>();
    for (var i = 0; i < name.Count; i++)
    {
        Users.Add(new User
        {
            Available = available[i],
            ImageUrl = userImageURL[i],
            Info = info[i],
            Name = name[i],
            NickName = nickname[i]
        });
    }
