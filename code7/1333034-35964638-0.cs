            var administrator = new List<Administrator>
            {
                new Administrator {AdministratorID = 1, AdministratorTitle = "Administrator Lvl 1"},
                new Administrator {AdministratorID = 1, AdministratorTitle = "Administrator Lvl 2"},
                new Administrator {AdministratorID = 1, AdministratorTitle = "Administrator Lvl 3"},
            };
            administrator.ForEach(s => context.Administrators.AddOrUpdate(p => p.AdministratorID, s));
            context.SaveChanges();
            var users = new List<User>
        {
            new User { FirstMidName = "Jason",   LastName = "Wan",
                EnrollmentDate = DateTime.Parse("2016-02-18"), DepartmentID = 1, DepotID = 1,AdministratorID = 1},
            new User { FirstMidName = "Andy", LastName = "Domagas",
                EnrollmentDate = DateTime.Parse("2016-02-18"), DepartmentID = 1,DepotID = 1,AdministratorID = 2},
            new User { FirstMidName = "Denis",   LastName = "Djohar",
                EnrollmentDate = DateTime.Parse("2016-02-18"), DepartmentID = 1 ,DepotID = 1,AdministratorID = 3},
            new User { FirstMidName = "Christine",   LastName = "West",
                EnrollmentDate = DateTime.Parse("2016-02-18"), DepartmentID = 1, DepotID = 1},
        };
            users.ForEach(s => context.Users.AddOrUpdate(p => p.FirstMidName, s));
            context.SaveChanges();
            users.ForEach(s => context.Users.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();
