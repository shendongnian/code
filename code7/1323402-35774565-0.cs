    public static void saveVideos(HttpContent content, String filename, bool overwrite)
        {
            string pathName = Path.GetFullPath(filename);
            using (Stream fs = new FileStream(pathName, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.None))
            {
                   byte[] buffer = content.ReadAsByteArrayAsync().Result;
                   fs.Write(buffer, 0, buffer.Length);
            }
        }
