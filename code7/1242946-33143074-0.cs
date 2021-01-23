        var cd = new MemberManager().GetMoreMembers(Url + "/");
        var activeMembers = cd.Where(am => am.MembershipStatus == "Active" || am.MembershipStatus == "Pending").ToList();
               
        var members = GetList(Url)
                      .Items
                      .Select(MemberFromSpListItem)
                      .Concat(activeMembers.Select(MemberFromActiveMember))
                      .ToList();
