    public IQueryable<Group> GetGroups()
    {
        string userEID = HttpContext.Current.Request.LogonUserIdentity.Name.ToUpper();
        var rs = db.Groups.Where(sg => sg.GroupActive == true).OrderBy(g => g.GroupName);
        var toReturn = new List<Group>();
        foreach (var gname in rs)
        {
                var groupOwner = getGroupOwner(gname.GroupSecurity);
                if (groupOwner == userEID)
                {
                    toReturn.Add(gname);
                }
        }
        return toReturn.AsQueryable<Group>();
    }
    
