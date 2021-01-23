    public static class FileHelper
    {
        public static void Delete(string path)
        {
            Console.WriteLine(path);
            File.Delete(path);
        }
    }
