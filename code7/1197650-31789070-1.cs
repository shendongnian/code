    public static String FindOnPath(string exeName)
    {
        foreach (string test in (Environment.GetEnvironmentVariable("PATH") ?? "").Split(';'))
        {
            string path = test.Trim();
            if (!String.IsNullOrEmpty(path) && File.Exists(path = Path.Combine(path, exeName)))
                return Path.GetFullPath(path);
        }
        return null;
    }
