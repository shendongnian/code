    var nameParts = searchString.Split(" ");
    var result = from info in joinInfo
                 where info.user.Email.Contains(searchString)
                 || info.user.Department.DepartmentName.Contains(searchString)
                 || info.detail.Name.Contains(nameParts[0])
                 || info.detail.Surname.Contains(nameParts[1])
                 || info.detail.Name.Contains(nameParts[0]) && info.detail.Surname.Contains(nameParts[1])
                 || info.role.RoleName.Contains(searchString)
                 select new UsersView
                 {
                     Id = info.user.Id,
                     Email = info.user.Email,
                     ...
                 };
