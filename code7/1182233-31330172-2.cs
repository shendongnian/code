    /// <summary>
    /// Returns a file in bytes
    /// </summary>
    public static class FileHelper
    {
        //Limited to 2^32 byte files (4.2 GB)
        public static byte[] GetBytesFromFile(string fullFilePath)
        {
            
            FileStream fs = null;
            
            try
            {
                fs = File.OpenRead(fullFilePath);
                var bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                return bytes;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
        }
    }
