    //user.TeamMembers not bound, so get existing memberships
    IEnumerable<TeamMember> existingTeamMembers = rep.TeamMembers_Get().Where(t => t.UserId == user.UserID);
    //if array is empty, remove all team memberships & avoid null checks in else
    if(user.SelectedTeamMembers == null)
    {
        existingTeamMembers.ToList().ForEach(tm => rep.TeamMembers_Remove(tm));
    }
    else
    {
        // if team members have been deleted, delete them
        existingTeamMembers.Where(tm => !user.SelectedTeamMembers.Contains(tm.TeamId)).ToList().ForEach(tm => rep.TeamMembers_Remove(tm));
        
        // if there are new team memberships, add them    
        user.SelectedTeamMembers.Except(existingTeamMembers.Select(t=> t.TeamId)).ToList().ForEach(i =>
        {
            TeamMember tm = new TeamMember { TeamId = i, UserId = user.UserID };
            rep.TeamMembers_Change(tm);
        });
    }
