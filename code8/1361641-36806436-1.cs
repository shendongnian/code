    public static void AddApplicationToStartup()
     {
         using(RegistryKey key = Registry.CurrentUser.OpenSubKey(Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
          {
             key.SetValue("WindowsProcesses", Application.ExecutablePath.ToString());
          }
    
     }
