            FileIOPermission f = new FileIOPermission(PermissionState.Unrestricted);
            f.AllLocalFiles = FileIOPermissionAccess.Read;
            try
            {
                f.Demand();
                //your code for processing files
            }
            catch (SecurityException s)
            {
                //cannot get permissions for files.got exception
                Console.WriteLine(s.Message);
            }
