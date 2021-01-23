                    var users = db.Companies.Include("TeamId")
                                            .Include("UserId")
                                            .Include("ConnectionId")
                                            .Select(x=>x.Teams.Users.Username)
    .where(x=>x.Teams.Users.Connections!=null && x.CompanyId==1).tolist();
