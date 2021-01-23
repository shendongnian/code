    class DirInfo
    {
    public string ParentDir { get; set; };
    public string DirName { get; set; };
    public string[] files { get; set; };
    public DirectoryInfo[] Dirs = null { get; set; };
    }
    
    List<DirInfo> Directories = new List<DirInfo>(); 
    //We don't really know the amount
    //unless we iterate through it, so you can make an array []
    
    private void DirSearch(System.IO.DirectoryInfo Root)
    {
    //You need to add you own validations when parent is null, or not subdirectories inside or 0 files inside, etc.
    Directories.Add(new DirInfo() { ParentDir = Root.Parent.Name, DirName = Root.Name, files = Root.GetFiles("*.*"), Dirs = Root.GetDirectories() };
    
    if(Root.Dirs != null)
    for(int i=0; i<Root.Dirs.Lenght; i++){
    
    DirSearch(Root.Dirs[i]);
    
    }
    
    }
