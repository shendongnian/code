    public static void ZipPath(string zipFilePath, string sourceDir, string pattern, bool withSubdirs, string password)
    {
        FastZip fz = new FastZip();
        if (password != null)
            fz.Password = password;
 
        fz.CreateZip(zipFilePath, sourceDir, withSubdirs, pattern);
    }
