    protected virtual bool IsLocked(FileInfo fileName)
    {
       FileStream fStream = null;
       try
       {
            fStream = fileName.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
       }
       catch (IOException)
       {
            return true;
       }
       finally
       {
            if (fStream != null)
            {
                 fStream.Close();
            }
       }
       return false;
    }
