    [StaticReplacement(typeof(File))]
    public static class FileSubstitute
    {
        public static void Delete(string path)
        {
            FileHelper.Delete(path);
        }
    }
