    static class Extensions
    {
        public static bool Exists(this StorageFile file)
        {
            return File.Exists(Path.Combine(file.Path));
        }
    }
