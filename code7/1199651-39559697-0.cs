    public static class ZipFileExtensions
    {
        public static Task SaveAsync(this ZipFile zipFile, string filePath)
        {
            zipFile.Save(filePath);
            return Task.FromResult(true);
        }
    }
