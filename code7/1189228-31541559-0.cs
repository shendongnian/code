    var disallowedFiles = directory.EnumerateFiles().Where(file => allowedCLEOFiles.Contains(file.Name)).ToList();
    
    if (disallowedFiles.Any())
    {
        DialogResult existsunallowedcleofiles = MessageBox.Show("Extraneous files found! Please remove them", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); 
        if(existsunallowedcleofiles == DialogResult.OK)
        {
            disallowedFiles.ForEach(file => File.Move(file.Name, "destination"));
        }
        return;
    }
