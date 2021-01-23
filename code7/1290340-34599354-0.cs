    static class Program
    {
        const string ProxyExtension = ".python-proxy";
        const string ResultExtension = ".python-proxy-result";
        [STAThread]
        static void Main(params string[] args)
        {
            if (args.Length != 1)
                return;
            if ("install".Equals(args[0], StringComparison.Ordinal))
            {
                var path = Application.ExecutablePath;
                SetAssociation(ProxyExtension, "PythonProxy", path, "Python Proxy");
            }
            else
            {
                var path = args[0];
                if (!File.Exists(path))
                    return;
                var serviceExt = Path.GetExtension(path);
                if (!ProxyExtension.Equals(serviceExt, StringComparison.OrdinalIgnoreCase))
                    return;
                path = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path).TrimEnd());
                var ext = Path.GetExtension(path);
                if (!".py".Equals(ext, StringComparison.OrdinalIgnoreCase))
                    return;
                var start = new ProcessStartInfo
                {
                    FileName = "python.exe",
                    Arguments = '"' + path + '"',
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                };
                using (var process = Process.Start(start))
                {
                    using (var reader = process.StandardOutput)
                    {
                        var result = reader.ReadToEnd();
                        var output = path + ResultExtension;
                        using (var mutex = new Mutex(true, "PythonProxy Mutex"))
                        {
                            File.WriteAllText(output, result);
                        }
                    }
                }
            }
        }
        public static void SetAssociation(string ext, string name, string openWithPath, string description)
        {
            using (var key = Registry.ClassesRoot.CreateSubKey(ext))
            {
                if (key == null)
                    return;
                key.SetValue("", name);
            }
            using (var key = Registry.ClassesRoot.CreateSubKey(name))
            {
                if (key == null)
                    return;
                key.SetValue("", description);
                using (var shellKey = key.CreateSubKey("shell"))
                {
                    if (shellKey == null)
                        return;
                    using (var openKey = shellKey.CreateSubKey("open"))
                    {
                        if (openKey == null)
                            return;
                        using (var commandKey = openKey.CreateSubKey("command"))
                        {
                            if (commandKey == null)
                                return;
                            commandKey.SetValue("", $"\"{openWithPath}\" \"%1\"");
                        }
                    }
                }
            }
            using (var key = Registry.CurrentUser.OpenSubKey($@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\{ext}"))
            {
                if (key != null)
                    key.DeleteSubKey("UserChoice", false);
            }
            Native.SHChangeNotify(Native.SHCNE_ASSOCCHANGED, Native.SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero);
        }
        class Native
        {
            public const uint SHCNE_ASSOCCHANGED = 0x08000000;
            public const uint SHCNF_IDLIST = 0x0000;
            [DllImport("shell32.dll")]
            public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
        }
    }
