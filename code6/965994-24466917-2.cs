    // instead of string[]. 
    public FileInfo[] getFlies { get; set; } // I suggest to change the name, maybe to Files? 
    // in your button1_click method, after the DialogResult is OK
    // getFiles in the dialog and getFlies is the array.
    public void button1_Click(object sender, EventArgs e)
    {
        var getfiles = new OpenFileDialog();  // again, change the name...maybe for dialog?
        getfiles.Filter = "All Files (*.*)|*.*"; // I fixed it. You missed the '*' .
        // more dialog initialization
        if(Dialog.Result.OK == getfiles.ShowDialog())
        {
            getFlies = getfiles.FileNames.Select( f => new FileInfo(f)).ToArray();
        }
    }
    
    // Now, in button3_click
    void button3_Click(object sender, EventArgs e)
    {
        foreach(var file in getFlies)
        {
            File.Copy(file.FullName, Path.Combine(getdirectory, file.Name));
        }
    }
