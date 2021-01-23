            FileIOPermission f = new FileIOPermission(PermissionState.Unrestricted);
            f.AllLocalFiles = FileIOPermissionAccess.Read;
            try
            {
                f.Demand();
                //process files
            }
            catch (SecurityException s)
            {
                Console.WriteLine(s.Message);
            }
