    List<string> Filenames = new List<string>()
    {
        "File1.jpg",
        "File2.jpg"
        //etc.
    };
    
    foreach(string s in Filenames)
    {
        Upload(s);
    }
    
    private void Upload(string filename)
    {
        string directory = @"\\path\\to\\directory";
        string fullpath = string.Format(@"{0}\{1}", directory, filename);
        if(File.Exists(fullpath))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Msg",     "alert('This file exists " + filename + "');", true);
        }
    }
    
