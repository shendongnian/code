    /*using System.Diagnostics;*/
    static void ReStart()
    {
        ProcessStartInfo startInfo = Process.GetCurrentProcess().StartInfo;
        startInfo.FileName = Application.ExecutablePath;
        var exit = typeof(Application).GetMethod("ExitInternal",
                            System.Reflection.BindingFlags.NonPublic |
                            System.Reflection.BindingFlags.Static);
        exit.Invoke(null, new object[] { });
        Process.Start(startInfo);
    }
