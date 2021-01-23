    private bool IsFileLocked()
    {
        try
        {
            using (File.Open(@"C:\Program Files\MyTestFiles\testing.dll", FileMode.Open))
            {
                return false;
            }
        }
        catch (IOException e)
        {
            // file locked
            return true;
        }
    }
