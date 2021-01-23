    // This is just to show that you need to create text box which needs to be set to multiline
    var tb = new TextBox();
    tb.Multiline = true;
    // search in: LocalMachine_32
    key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
    foreach (String keyName in key.GetSubKeyNames())
    {
        RegistryKey subkey = key.OpenSubKey(keyName);
        // here just add a line with a program name        
        string name = subkey.GetValue("DisplayName") as string;      
        if (!string.IsNullOrEmpty(name))
        {
            tb.Text += name;
            tb.Text += "\n\r";
        }
    }
