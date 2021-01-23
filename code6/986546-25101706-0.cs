    from u in context.Users
    join au in context.UserAuthDetails on u.UserID equals au.UserID && 
                            context.UserAuthDetails.Where(au2 => au2.UserID == u.UserID)
                                            .OrderByDescending(au2 => au2.CreatedOn)
                                            .Select(au => au2.CreatedOn)
                                            //.Take(1) //you have this in SQL
                                            .Any(auc=>auc == au.CreatedOn)
                     
