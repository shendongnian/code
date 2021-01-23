    try
                {
                    new System.Security.Permissions.RegistryPermission(System.Security.Permissions.PermissionState.Unrestricted).Assert();
                    hKey.DeleteSubKeyTree(strPath);
                    flag1 = true;
                }
                catch (Exception obj1) //when (?)
                {
                }
                finally
                {
                    System.Security.Permissions.RegistryPermission.RevertAssert();
                } 
