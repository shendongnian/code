    private static void QshareFolder(string FolderPath, string ShareName, string Description)
        {
            try
            {
                // Create a ManagementClass object
                ManagementClass managementClass = new ManagementClass("Win32_Share");
                // Create ManagementBaseObjects for in and out parameters
                ManagementBaseObject inParams = managementClass.GetMethodParameters("Create");
                ManagementBaseObject outParams;
                // Set the input parameters
                inParams["Description"] = Description;
                inParams["Name"] = ShareName;
                inParams["Path"] = FolderPath;
                inParams["Type"] = 0x0; // Disk Drive
                //Another Type:
                // DISK_DRIVE = 0x0
                // PRINT_QUEUE = 0x1
                // DEVICE = 0x2
                // IPC = 0x3
                // DISK_DRIVE_ADMIN = 0x80000000
                // PRINT_QUEUE_ADMIN = 0x80000001
                // DEVICE_ADMIN = 0x80000002
                // IPC_ADMIN = 0x8000003
                //inParams["MaximumAllowed"] = int maxConnectionsNum;
                // Invoke the method on the ManagementClass object
                outParams = managementClass.InvokeMethod("Create", inParams, null);
                // Check to see if the method invocation was successful
                if ((uint)(outParams.Properties["ReturnValue"].Value) != 0)
                {
                    throw new Exception("Unable to share directory.");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "error!");
            }
        }
