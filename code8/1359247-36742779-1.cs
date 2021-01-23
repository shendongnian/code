    public void ProcessFile(FileContents fileContents)
    {
        bool cleanPhoneFields = true;
        foreach (FileRow row in fileContents.FileRows)
        {
            if (cleanPhoneFields)
                cleanPhoneFields = CleanPhoneFields(row, fileContents.Mappings, fc);
            // Other stuff
        }
    }
