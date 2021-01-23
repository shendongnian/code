    public IEnumerable<UserPoco> GetUserDetail(string searchBy, string searchValue)
    {
        List<User> usr = new List<User>();
        public List<User> usr { get; set; };
        var query = (from u in db.Users
                     join ut in db.UserLicenseTypes
                         on u.UserId equals ut.UserId
                     join tl in db.ToolsLicenseTypes
                     on ut.ToolLicenseTypeId equals tl.ToolLicenseTypeId
                     join tm in db.LicenseTypeMasters
                     on tl.LicenseTypeId equals tm.LicenseTypeId
                     where u.FirstName == searchBy
                     select new UserPoco
                     {
                         FirstName = u.FirstName,
                         LastName = u.LastName,
                         Email = u.Email,
                         LicenseAllocated. = tm.LicenseTypes
                     }).ToList();
       return query;
    }
