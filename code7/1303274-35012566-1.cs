    List<string> lstAliasImage = new List<string>()
    {
        "alias1.jpg",
        "alias2.jpg",
        "alias3.jpg"
    };
    
    List<string> lstNameImage = new List<string>();
    {
        @"C:\Images\123abc.jpg", // <-- will be replaced with `alias1.jpg`
        @"C:\Images\ab12.jpg",   // <-- will be replaced with `alias2.jpg`
        @"C:\Images\ab34.jpg"    // <-- will be replaced with `alias3.jpg`
    };
    
    for(int i = 0; i < lstNameImage.Count; i++)
    {
        File.Move(lstNameImage[i], Path.GetDirectoryName(lstNameImage[i]) + "\\" + lstAliasImage[i] + i);
    }
