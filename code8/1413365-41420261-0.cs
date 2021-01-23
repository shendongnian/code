    public void CreateShortCut(string shorcutPath, string shortcutTarget)
    {
        byte[] bytes = null;
    
        // Disable impersonation
        using (System.Security.Principal.WindowsImpersonationContext ctx = System.Security.Principal.WindowsIdentity.Impersonate(IntPtr.Zero))
        {
            // Get a temp file name (the shell commands won't work without .lnk extension)
            var path = Path.GetTempPath();
            string temp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".lnk");
            try
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(temp);
                shortcut.TargetPath = shortcutTarget;
                shortcut.Save();
                bytes = System.IO.File.ReadAllBytes(temp);
            }
            finally
            {
                if (System.IO.File.Exists(temp)) System.IO.File.Delete(temp);
            }
        }
        // Impersonation resumed
        System.IO.File.WriteAllBytes(shorcutPath, bytes);
    }
