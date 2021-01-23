    namespace UserManagement.Implementation
    {
        public class UserManagementApplicationService : IUserManagementApplicationService
        {
            private User.IBusiness              userBusiness;
            private UserPermissions.IBusiness   userPermissionsBusiness;
            private Permission.IBusiness        permissionBusiness;
    
            public UserManagementApplicationService(User.IBusiness userBusiness, UserPermission.IBusiness userPermissionsBusiness, Permission.IBusiness permissionBusiness)
            {
                this.userBusiness               = userBusiness;
                this.userPermissionsBusiness    = userPermissionsBusiness;
                this.permissionBusiness         = permissionBusiness;
            }
    
            public Response EditUser(Guid userId)
            {
                ...
            }
    
            public Response SaveUser(EditUserResponse.user user)
            {
                ...
            }
            
            public Response ViewUser(Guid userId)
            {
                ...
            }
    
        }
    }
