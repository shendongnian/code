    var Users = from usr in
                (from au in _lldat.aspnet_Users
                         join am in _lldat.aspnet_Membership on au.UserId equals am.UserId
                         select new  { au.UserName, am.LoweredEmail })
                group usr by new { usr.LoweredEmail } into grp 
                select new {
                               uEMail = grp.Key,
                               uName = grp.Aggregate((a, b) => new {UserName = (a.UserName + ", " + b.UserName + ", "), LoweredEmail = a.LoweredEmail }).UserName 
                           };
