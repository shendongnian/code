     public bool CanRequestNotifications()
            {
    
                try
                {
                    var perm = new SqlClientPermission(PermissionState.Unrestricted);
                    perm.Demand();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
