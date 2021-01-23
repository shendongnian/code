    List<tblUsersTypeC> usertype = new List<tblUsersTypeC>();
    userToInsertList.ForEach(o => usertype.Add(new tblUsersTypeC() 
        { 
            isPrivite = ((o.Counts.FollowedBy + o.Counts.Follows + o.Counts.Media) == 0), 
            UserName = o.Username, 
            WebsiteUrl = o.Website 
        }));
