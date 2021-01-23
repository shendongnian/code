    public static bool IsPasswordProtectedZipFile(string path)
    {
        using (FileStream fileStreamIn = new FileStream(path, FileMode.Open, FileAccess.Read))
        using (ZipInputStream zipInStream = new ZipInputStream(fileStreamIn))
        {
            ZipEntry entry = zipInStream.GetNextEntry();
            return entry.IsCrypted;
        }
    }
