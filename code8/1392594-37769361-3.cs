    /*using System.Diagnostics;*/
    public static void Restart()
    {
        ProcessStartInfo startInfo = Process.GetCurrentProcess().StartInfo;
        startInfo.FileName = Application.ExecutablePath;
        var exit = typeof(Application).GetMethod("ExitInternal",
                            System.Reflection.BindingFlags.NonPublic |
                            System.Reflection.BindingFlags.Static);
        exit.Invoke(null, null);
        Process.Start(startInfo);
    }
