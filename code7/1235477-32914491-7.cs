      using System.Collections.Generic;
        using System.IO;
        using System.Linq;
    
        namespace TestPopWpfWindow
        {
        
        public static class UsbDriveListProvider
        {
    
    
            public static IEnumerable<DriveInfo> GetAllRemovableDrives()
            {
                var driveInfos = DriveInfo.GetDrives().AsEnumerable();
                driveInfos = driveInfos.Where(drive => drive.DriveType == DriveType.Removable);
                return driveInfos;
            }
    
        }
    }
