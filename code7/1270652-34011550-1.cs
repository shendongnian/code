    public static void Main(string[] args)
    {
        var startInfo = new ProcessStartInfo("path to csi.exe")
        {
            CreateNoWindow = true,
            Arguments = args[1],
        };
        Process.Start(startInfo);
    }
