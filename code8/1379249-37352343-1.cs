    using System.Diagnostics;
    using System.Windows.Forms;
    
    Debug.Print("Total Number Of Monitors: {0}", Screen.AllScreens.Length);
    foreach (Screen scr in Screen.AllScreens)
    {
        Debug.Print(scr.DeviceName);
    }
