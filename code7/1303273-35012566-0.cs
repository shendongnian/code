    List<string> lstAliasImage = new List<string>()
    {
        "alias1.jpg",
        "alias2.jpg",
        "alias3.jpg"
    };
    
    List<string> lstNameImage = new List<string>();
    {
        @"C:\Images\123abc.jpg",
        @"C:\Images\ab12.jpg",
        @"C:\Images\ab34.jpg"
    };
    
    for(int i = 0; i < imgPaths.Count; i++)
    {
        File.Move(imgPaths[i], Path.GetDirectoryName(imgPaths[i]) + "\\" + lstAliasImage[i] + i);
    }
