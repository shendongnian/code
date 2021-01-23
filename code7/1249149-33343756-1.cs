    List<tblUsersTypeC> usertype = userToInsertList.Select(o => new tblUsersTypeC() 
        { 
            isPrivite = ((o.Counts.FollowedBy + o.Counts.Follows + o.Counts.Media) == 0), 
            UserName = o.Username, 
            WebsiteUrl = o.Website 
        }).ToList();
