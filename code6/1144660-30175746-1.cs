    public static List<int> GetEligibleUsersForTeam(Team subTeam)
    {
        List<int> ineligibleUsers = new List<int>();
        ineligibleUsers.Add(subTeam.ManagerId);
        Team parent = db.Teams.Find(subTeam.ParentTeamId);
        while (parent != null) {
            ineligibleUsers.AddRange(parent.Users.Select(x = x.Id).ToList());
            Team parent = db.Teams.Find(parent.ParentTeamId);
        }
        return db.Users.AsEnumerable().Where(x => ineligibleUsers.Contains(x.Id) == false).ToList();
    }
