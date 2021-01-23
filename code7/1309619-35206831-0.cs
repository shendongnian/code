    @"\\server\folder\Some Folder"
    WriteToFile("Starting Word application");
    Application word = new Word.Application();
    object missing = Type.Missing;
    var sourcefile = new System.IO.FileInfo(path);
    string SomeShare = @"\\SomeServer\Someshare\Somepath";
    System.IO.FileInfo WorkFile = new System.IO.FileInfo(System.IO.Path.Combine(SomeShare, sourcefile.Name));
            
    // check if the created file ends with .doc. 
    System.Diagnostics.Debug.WriteLine(path);
    if (!path.ToLower().EndsWith(".doc"))
    {
         return "";
    }
    word.Visible = false;
    WriteToFile("Opening doc as read only");
    // open readonly            
    System.Diagnostics.Debug.WriteLine(sourcefile.FullName);
    var doc = word.Documents.Open(FileName: WorkFile.FullName, ReadOnly: true);
    }  
