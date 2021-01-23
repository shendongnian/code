    IEnumerable<ViewModels.User.IndexViewModel> model;
    IEnumerable<Models.ApplicationUser> users;
    var profilesDtos = _profileService.GetAll();
    using (var context = new Models.ApplicationDbContext())
    {
        users = context.Users.ToList();
    }
    model = (from u in users
	join p in profilesDtos on u.Id equals p.Id into tempTbl
	from up in tempTbl.DefaultIfEmpty()
	select new ViewModels.User.IndexViewModel
    {
        Id = u.Id,
        Email = u.Email,
        PhoneNumber = u.PhoneNumber,
        LockedOutTill = u.LockoutEndDateUtc ?? default(DateTime),
        Roles = UserManager.GetRoles(u.Id),
	    FirstName = up!= null? up.FirstName : string.Empty;
        LastName =  up!= null? up.LastName  : string.Empty;
    }).ToList();
