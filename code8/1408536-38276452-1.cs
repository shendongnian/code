    WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
    bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
    
    if (!hasAdministrativeRight)
    {
        RunElevated(Application.ExecutablePath);
        this.Close();
        Application.Exit();
    }
    
    private static bool RunElevated(string fileName)
    {
        //MessageBox.Show("Run: " + fileName);
        ProcessStartInfo processInfo = new ProcessStartInfo();
        processInfo.UseShellExecute = true;
        processInfo.Verb = "runas";
        processInfo.FileName = fileName;
        try
        {
            Process.Start(processInfo);
            return true;
        }
        catch (Win32Exception)
        {
            //Do nothing as user cancelled UAC window.
        }
        return false;
    }
 
