    namespace UserDomain
    {
        public class User : Entity<User, User.DataObject, User.DataObjectList, User.IBusiness, User.IDataAccess, Guid>
        {
            public class DataObject : BaseDataObject
            {
                public string FirstName;
                public string LastName;
                public bool IsActive { get; }
            }
            public class DataObjectList : BaseDataObjectList {}
            public interface IBusiness : IBaseBusiness
            {
                void DeactivateUser(Guid userId);
            }
            public interface IDataAccess : IBaseDataAccess {}
            public class Business
            {
                public Business(User.IDataAccess dataAccess) : base(dataAccess) {}
                public void DeactivateUser(Guid userId)
                {
                    ...
                }
            }
            
        }
        public class UserPermission : Entity<UserPermission, UserPermission.DataObject, UserPermission.DataObjectList, UserPermission.IBusiness, UserPermission.IDataAccess, Guid>
        {
            public class DataObject : BaseDataObject
            {
                public Guid PermissionId;
                public Guid UserId;
            }
            public class DataObjectList : BaseDataObjectList {}
            public interface IBusiness : IBaseBusiness {}
            public interface IDataAccess : IBaseDataAccess {}
            public class Business
            {
                public Business(UserPermission.IDataAccess dataAccess) : base(dataAccess) {}
            }
            
        }
        public class Permission : Entity<Permission, Permission.DataObject, Permission.DataObjectList, Permission.IBusiness, Permission.IDataAccess, Guid>
        {
            public class DataObject : BaseDataObject
            {
                public string Code;
                public string Description;
            }
            public class DataObjectList : BaseDataObjectList {}
            public interface IBusiness : IBaseBusiness {}
            public interface IDataAccess : IBaseDataAccess {}
            public class Business
            {
                public Business(Permission.IDataAccess dataAccess) : base(dataAccess) {}
            }
            
        }
    }
