    Chilkat.Rar rar = new Chilkat.Rar();
    
    //  Note: The Chilkat RAR functionality only provides the ability
    //  to open, list, and "unrar" (i.e. extract) RAR archives.  It does
    //  not provide the ability to create RAR archives.
    
    //  Also, the Chilkat RAR functionality is free.  It does not
    //  require a license to use indefinitely.
    
    bool success;
    string location = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "update.rar";
    string unzipLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/update/";
    success = rar.Open(location);
    if (success != true) {
        MessageBox.Show(rar.LastErrorText);
        return;
    }
    
    success = rar.Unrar(unzipLocation);
    if (success != true) {
        MessageBox.Show(rar.LastErrorText);
    }
    else {
        MessageBox.Show("Success.");
        // Use file stream to load your text file. Find the matching username and password as needed. Figure that out since it varies depending on the format of the content of your text file.
        // Other processing
    }
