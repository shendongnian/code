    private Business.User Transform(User user)
    {
        return new Business.User()
        {
            .Username = user.Username,
            .Name = user.Name
        }//Etc; copy all fields you care about into your business object.
    }
    foreach (var item in remote.Users)
            lstUsers.Add(this.Transform(item));
    foreach (var item in local.Users)
            lstUsers.Add(this.Transform(item));
    var results = lstUsers.Distinct().ToList();
