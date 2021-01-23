    public void GetConnectedDevices(ref System.IO.DriveInfo[] ConnectedDrives)
    {
        //Put all connected drives into an array
        System.IO.DriveInfo[] myDrives = System.IO.DriveInfo.GetDrives();
        List<System.IO.DriveInfo> Drives = new List<System.IO.DriveInfo>();
        foreach (System.IO.DriveInfo info in myDrives)
        {
            if (info.DriveType == System.IO.DriveType.Removable && info.IsReady)
            {
                Drives.Add(info);
            }
        }
        if (Drives.Count > 0)  //1
        {
            ConnectedDrives = Drives.ToArray<System.IO.DriveInfo>();
        }
    }
