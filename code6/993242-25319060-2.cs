    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management;
    using System.Text;
    using System.Threading.Tasks;
    namespace EditBcdStore
    {
        public class BcdStoreAccessor
        {
            public const int BcdOSLoaderInteger_SafeBoot = 0x25000080;
            public enum BcdLibrary_SafeBoot
            {
                SafemodeMinimal = 0,
                SafemodeNetwork = 1,
                SafemodeDsRepair = 2
            }
            private ConnectionOptions connectionOptions;
            private ManagementScope managementScope;
            private ManagementPath managementPath;
            public BcdStoreAccessor()
            {
                connectionOptions = new ConnectionOptions();
                connectionOptions.Impersonation = ImpersonationLevel.Impersonate;
                connectionOptions.EnablePrivileges = true;
                managementScope = new ManagementScope("root\\WMI", connectionOptions);
                managementPath = new ManagementPath("root\\WMI:BcdObject.Id=\"{fa926493-6f1c-4193-a414-58f0b2456d1e}\",StoreFilePath=\"\"");
            }
            public void SetSafeboot()
            {
                ManagementObject currentBootloader = new ManagementObject(managementScope, managementPath, null);
                currentBootloader.InvokeMethod("SetIntegerElement", new object[] { BcdOSLoaderInteger_SafeBoot, BcdLibrary_SafeBoot.SafemodeMinimal });
            }
            public void RemoveSafeboot()
            {
                ManagementObject currentBootloader = new ManagementObject(managementScope, managementPath, null);
                currentBootloader.InvokeMethod("DeleteElement", new object[] { BcdOSLoaderInteger_SafeBoot });
            }
        }
    }
