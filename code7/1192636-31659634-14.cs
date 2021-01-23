    namespace UserManagement.Contracts
    {
        public class ReviewUserResponse : Response<ReviewUserResponse>
        {
            public class UserPermission
            {
                public  Guid    id;
                public  string  permission; // <- formatted as "permissionCode [permissionDescription]"
            }
    
            public class User
            {
                public  Guid                    id;
                public  string                  firstName;
                public  string                  lastName;
                public  List<UserPermissions>   permissions;
            }
    
            public User user;
        }
        public class EditUserResponse : Response<EditUserResponse>
        {
    
            public class Permission
            {
                public  Guid    id;
                public  string  permissionCode;
                public  string  description;
            }
        
            public class UserPermission
            {
                public  Guid    id;
                public  Guid    permissionId;
            }
    
            public class User
            {
                public  Guid                    id;
                public  string                  firstName;
                public  string                  lastName;
                public  List<UserPermissions>   permissions;
            }
            public  List<Permission>    knownPermissions;
            public  User                user;
    
        }
    
        public interface IUserManagementApplicationService : IBaseApplicationService
        {
        
            Response EditUser(Guid userId);
            Response SaveUser(EditUserResponse.user user);
            Response ViewUser(Guid userId);
        
        }
    }
