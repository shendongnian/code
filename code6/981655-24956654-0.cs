    public static string ResourceFolderPath
    {
        get
        {
            string path, applicationDirectory = Path.GetDirectoryName(
                Assembly.GetEntryAssembly().Location);
            if (applicationDirectory.Contains(Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile))) path = Path.Combine(
                applicationDirectory, "Resources");
            else path = Path.Combine(Directory.GetParent(applicationDirectory).Parent.
                FullName, "Resources");
            return path;
        }
    }
