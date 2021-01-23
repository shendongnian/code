    new ApplicationUser
    {
        UserName = "jackie@hotmail.com",
        FirstMidName = "Jackie",
        LastName = "Chan",
        Email = "jasonw@rs.kiwi.nz",
        PasswordHash = password,
        Roles =
        {
            new ApplicationUserRole
            {
                RoleId = 1
            }
        },
        EnrollmentDate = DateTime.Parse("2016-02-18"),
        DepartmentID = 1,
        DepotID = 1,
        IsAdministrator = true,
        SecurityStamp = Guid.NewGuid().ToString()
    }
