    public static class FileHelper
        {
            public static void EraseFile(string fileName)
            {
                var fileInfo = new FileInfo(fileName);
                var zeroBuffer = new byte[4096];
                using (var file = new FileStream(fileName, FileMode.Open, FileAccess.Write))
                {
                    while (file.Position < fileInfo.Length)
                    {
                        var bytesToWrite = (int)Math.Min(4096, fileInfo.Length - file.Position);
                        file.Write(zeroBuffer, 0, bytesToWrite);
                    }
                    file.Flush(true);
                }
                File.Delete(fileName);
            }
        }
