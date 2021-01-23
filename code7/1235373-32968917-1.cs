        public class PermissionController : INotifyPropertyChanged
        {
            #region Singleton
            ...
            //constructor
            private PermissionController()
            {
                Initialize();
                UserModel.Instance.LoginChanged += new LoginChangedEventHandler(UpdatePermissions);
            }
            #endregion
            //role names from database as string const
            private const string PACKER = "Packer";
            private const string CHIEF = "Lagerleiter";
            private const string QSWORKER = "QSMitarbeiter";
            private const string DEVELOPER = "Entwickler";
            PropertyInfo[] _localProperties;
            //Permissions defined as properties
            public Permission WEstart { get; private set; }
            public Permission WEreset { get; private set; }
            public Permission WEclose { get; private set; }
            public Permission Manage { get; private set; }
            public Permission TestPhase { get; private set; }
            private void Initialize()
            {
                _localProperties = typeof(PermissionController).GetProperties();
            
                WEwork          = new Permission(PACKER, CHIEF);
                WEreset         = new Permission(CHIEF);
                WEclose         = new Permission(PACKER, CHIEF);           
                Manage          = new Permission(CHIEF);
                TestPhase       = new Permission(DEVELOPER);
            }
            private void UpdatePermissions(object sender, EventArgs e)
            {            
                var currentUser = (UserModel)sender;
            
                //if user is logged out -> return
                if (!currentUser.IsLoggedIn)
                    return;
                var permissionType = typeof(Permission);
                foreach (PropertyInfo property in _localProperties)
                {
                    if (property.PropertyType != permissionType)
                        continue;
                    var permission = (Permission)property.GetValue(this, null);
                    permission.IsAllowed = false;
                    if (permission.AccessControllList.Contains(currentUser.UserRole))
                    {
                        permission.IsAllowed = true;
                    }
                    OnPropertyChanged(property.Name);
                }
            }
            #region INotifyPropertyChangedImplementation
            ...
            protected virtual void OnPropertyChanged(string propertyName)
            {
                ...
            }
            ...
            #endregion 
        }
