    RegistryKey _key = Registry.ClassesRoot.OpenSubKey("Folder\\Shell", true);
    RegistryKey newkey = _key.CreateSubKey("My Menu Item");
    RegistryKey subNewkey = newkey.CreateSubKey("Command");
    subNewkey.SetValue("", "C:\\yourApplication.exe");
    subNewkey.Close();
    newkey.Close();
    _key.Close();
