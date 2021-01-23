    if (IsAdministrator())
    {
        // run whatever you want as elevated user
    }
    else
    {
        //launch the same app as admin
        ExecuteAsAdmin(PATHH_TO_THE_SAME_APP.EXE);
        //execute whatever you want as current user.
    }
    public static void ExecuteAsAdmin(string fileName)
            {
                Process proc = new Process();
                proc.StartInfo.FileName = fileName;
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "runas";
                
                proc.Start();
                proc.WaitForExit();
            }
    
    public static bool IsAdministrator()
            {
                var identity = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
    hope that helps!
