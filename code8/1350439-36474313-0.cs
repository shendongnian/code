    foreach (FileInfo file in files)
    {
        String messageContents = File.ReadAllText(file.FullName);
        bool toQuarantine = textwords.Any(keyWord => messageContents.Contains(keyWord));
    
        try
        {
            File.Move(file.FullName, toQuarantine ? File_quarantine : File_Valid);
        }
        catch (IOException cannot_Move_File)
        {
            MessageBox.Show("The process has failed: {0}", cannot_Move_File.ToString());
        }
    }
