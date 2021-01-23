     main
     {  
     Permission permission= new Permission();
     permission = share(service, file.Id, <user email>, "user", "owner");
     }
     public static Permission share(DriveService service, String fileId, String value,
      String type, String role)
        {
            Permission newPermission = new Permission();
            newPermission.Value = value;
            newPermission.Type = type;
            newPermission.Role = role;
            try
            {
                return service.Permissions.Insert(newPermission, fileId).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            return null;
        }
