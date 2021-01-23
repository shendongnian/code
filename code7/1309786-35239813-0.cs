    private static List<DirectoryInfo> list_to_copy = new List<DirectoryInfo>();
    DirectoryInfo usbdirectory;
    backing_up_interface backing_up_interface;
    bool newfilesfound = false;
    private void usbchecker_timer_Tick(object sender, EventArgs e)
    { 
        foreach (DriveInfo usbname in DriveInfo.GetDrives().Where(usbproperty => usbproperty.DriveType == DriveType.Removable && usbproperty.IsReady))
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + usbname.VolumeLabel + @"\"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory.ToString() + usbname.VolumeLabel + @"\");
                usbdirectory = new DirectoryInfo(usbname.Name);
                if (!list_to_copy.Contains(usbdirectory))
                {
                    list_to_copy.Add(usbdirectory);
                    newfilesfound = true;
                }
            }
        }
        if (newfilesfound == true)
        {
            process_copy();
            newfilesfound = false;
        }
    }
    //where information is passed to
    private void process_copy()
    {
        for (int i = 0; i < list_to_copy.Count; i++)
        {
            backing_up_interface = new backing_up_interface(list_to_copy[i]);
            backing_up_interface.Show(); MessageBox.Show(list_to_copy[i].ToString());
        }
    }
