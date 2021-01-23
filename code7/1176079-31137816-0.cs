    Permission newPermission = new Permission();
    newPermission.Value = "yourdriveaccount@domain.com";
    newPermission.Type = "user";
    newPermission.Role = "reader";
    service.Permissions.Insert(newPermission, file.Id).Execute();
