    string file1 = "1346670589521421983450911196954093762922.nii";
    string file2 = "1.3.46.670589.5.2.14.2198345091.1196954093.762922.dcm";
    //#1 remove extension
    string file1name = System.IO.Path.GetFileNameWithoutExtension(file1);
    string file2name = System.IO.Path.GetFileNameWithoutExtension(file2);
    //#2 remove .
    string file2normalized = file2name.Replace(".", string.Empty);
    //# compare
    bool equal = file1name == file2normalized;
