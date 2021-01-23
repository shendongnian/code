    static public void replaceOutlook()
    {
        // OST PATH
        string ostPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Microsoft\Outlook");
        // LIST OF FILE PATHS IN OST PATH
        string[] fileEntries = Directory.GetFiles(ostPath);
        try
        {
            // CHECK EACH FILE PATH
            foreach (string fileName in fileEntries)
            {
                // IS IT AN OST?
                if (Path.GetExtension(fileName).ToLower() == ".ost")
                {
                    // TRY AND DELETE OLD FILE, WON'T THROW EXCEPTION IF FILE DOESN'T EXIST
                    File.Delete(fileName + ".OLD");
                    // RENAME FILE
                    File.Move(fileName, fileName + ".OLD");
                }
            }
        }
        catch
        {
            // Blah blah....
        }
    }
