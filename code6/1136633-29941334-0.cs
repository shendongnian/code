     public static bool IsFileLocked(FileInfo file)
            {
                FileStream stream = null;
    
                try
                {
                    stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                }
                catch
                {
                    return true;
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                }
    
                return false;
            }
