    private static bool IsFileLocked()
    {
        try
        {
            using (FileStream fs = File.Open(@"C:\path\to\non_existant_file.docx", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                fs.ReadByte();
                return false;
            }
        }
        catch (IOException ex)
        {
            int errorCode = ex.HResult & 0xFFFF;
            return errorCode == 32 || errorCode == 33; // lock or sharing violation
        }
    }
