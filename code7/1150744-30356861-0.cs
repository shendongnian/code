    public static string FindExePath(string exe)
    {
        exe = Environment.ExpandEnvironmentVariables(exe);
        if (!File.Exists(exe))
        {
            if (Path.GetDirectoryName(exe) == String.Empty)
            {
                foreach (string test in (Environment.GetEnvironmentVariable("PATH") ?? "").Split(';'))
                {
                    string path = test.Trim();
                    if (!String.IsNullOrEmpty(path) && File.Exists(path = Path.Combine(path, exe)))
                        return Path.GetFullPath(path);
                }
            }
            throw new FileNotFoundException(new FileNotFoundException().Message, exe);
        }
        return Path.GetFullPath(exe);
    }
