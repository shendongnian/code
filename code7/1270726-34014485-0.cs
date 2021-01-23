    List<string> list = new List<string>();
    var rs = context.Roles.Where(x => x.Name == role).SingleOrDefault().Id; // where role is your role in which you want to find
    var users = context.Users.Where(item => item.Roles.Any(x => x.RoleId == rs)).ToList();
    foreach (var a in users)
    {
        list.Add(a.Email);
    }
