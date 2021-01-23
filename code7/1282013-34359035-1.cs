    public static bool FileHasWriteAccess(string Path)
    {
        try
        {
            System.IO.File.Open(Path, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite).Dispose();
            return true;
        }
        catch (System.IO.IOException)
        {
            return false;
        }
    }
