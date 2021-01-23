     public static class C_ServiceControllerExtension
        {
            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern Boolean ChangeServiceConfig(
                IntPtr hService,
                UInt32 nServiceType,
                UInt32 nStartType,
                UInt32 nErrorControl,
                String lpBinaryPathName,
                String lpLoadOrderGroup,
                IntPtr lpdwTagId,
                [In] char[] lpDependencies,
                String lpServiceStartName,
                String lpPassword,
                String lpDisplayName);
    
            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern IntPtr OpenService(
                IntPtr hSCManager, string lpServiceName, uint dwDesiredAccess);
    
            [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr OpenSCManager(
                string machineName, string databaseName, uint dwAccess);
    
            [DllImport("advapi32.dll", EntryPoint = "CloseServiceHandle")]
            public static extern int CloseServiceHandle(IntPtr hSCObject);
    
            private const uint SERVICE_NO_CHANGE = 0xFFFFFFFF;
            private const uint SERVICE_QUERY_CONFIG = 0x00000001;
            private const uint SERVICE_CHANGE_CONFIG = 0x00000002;
            private const uint SC_MANAGER_ALL_ACCESS = 0x000F003F;
    
            /// <summary>
            /// Changes the configuration of the service
            /// </summary>
            /// <param name="svc">Service controller</param>
            /// <param name="mode">ServiceStartMode || 0</param>
            /// <param name="type">ServiceType || 0</param>
            public static bool ChangeServiceConfiguration(this ServiceController svc, ServiceStartMode mode, ServiceType type)
            {
                uint uMode = SERVICE_NO_CHANGE;
                uint uType = SERVICE_NO_CHANGE;
                if (mode > 0) 
                {
                    uMode = (uint)mode;
                }
    
                if (type > 0) 
                {
                    uType = (uint)type;
                }
    
                var scManagerHandle = OpenSCManager(null, null, SC_MANAGER_ALL_ACCESS);
                if (scManagerHandle == IntPtr.Zero)
                {
                    throw new ExternalException("Open Service Manager Error");
                }
    
                var serviceHandle = OpenService(
                    scManagerHandle,
                    svc.ServiceName,
                    SERVICE_QUERY_CONFIG | SERVICE_CHANGE_CONFIG);
    
                if (serviceHandle == IntPtr.Zero)
                {
                    throw new ExternalException("Open Service Error");
                }
    
                var result = ChangeServiceConfig(
                    serviceHandle,
                    uType,
                    uMode,
                    SERVICE_NO_CHANGE,
                    null,
                    null,
                    IntPtr.Zero,
                    null,
                    null,
                    null,
                    null);
    
                if (result == false)
                {
                    int nError = Marshal.GetLastWin32Error();
                    var win32Exception = new Win32Exception(nError);
                    return false;
                    //throw new ExternalException("Could not change service start type: " + win32Exception.Message);
                }
    
                CloseServiceHandle(serviceHandle);
                CloseServiceHandle(scManagerHandle);
                return true;
            }
        }
