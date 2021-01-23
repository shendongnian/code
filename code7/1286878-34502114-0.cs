    var team = /*...*/;
    var teamMembers = Db.TeamMembers
        .Where(c => c.TeamId == team.Id && c.MemberId != team.CaptainId)
        .ToList();
    var teamMemberIds = teamMembers.Select(c => c.MemberId);
    var members = MemberManager.Users
        .Where(c => teamMemberIds.Any(x => c.Id == x))
        .ToList();
    var j = teamMembers
        .Join(members, c => c.MemberId, cm => cm.Id, (c, cm) => new
            {
                TeamMember = c,
                Member = cm
            });
