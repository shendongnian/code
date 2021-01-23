    ManagementObjectSearcher Processes = new ManagementObjectSearcher("SELECT * FROM Win32_Process");
        foreach (ManagementObject Process in Processes.Get())
        {
            if (Process["ExecutablePath"] != null)
            {
                 string ExecutablePath = Process["ExecutablePath"].ToString();
                 string[] OwnerInfo = new string[2];
                 Process.InvokeMethod("GetOwner", (object[])OwnerInfo);
                 Console.WriteLine(string.Format("{0}: {1}", System.IO.Path.GetFileName(ExecutablePath), OwnerInfo[0]));
            }
         }
