    public static void SafeCopy(string src, string dest)
    {
        if (!File.Exists(dest))
        {
            File.Copy(src, dest);
        }
        else
        {
            for (var i = 1; ; i++)
            {
                var newName = Path.Combine(Path.GetDirectoryName(dest), Path.GetFileName(dest) + " - Copy " + i + Path.GetExtension(dest));
                if (!File.Exists(newName))
                {
                    File.Copy(src, newName);
                    break;
                }
            }
        }
    }
