    private void RemoveHiddenNReadOnly()
    {
        if (File.Exists) // File here is the FileInfo of the xml file for the class
        {
            File.Attributes &= ~FileAttributes.Hidden; // Remove Hidden Flag 
            File.Attributes &= ~FileAttributes.ReadOnly; // Remove ReadOnly Flag
        }
    }
