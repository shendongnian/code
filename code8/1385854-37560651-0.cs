    public bool IsFileBelongToFolderName(string filePath, string name){
        return filePath.ToLower().Contains(@"/"+name.ToLower().Replace(@"/", "")+@"/");
    }
    string filePath = @"C:/vietnam/hello/world/welcome.jpg";
    
    IsFileBelongToFolderName(filePath,"vietnam"); // return True
    IsFileBelongToFolderName(filePath,"Vietnam"); // return True
    IsFileBelongToFolderName(filePath,"Vietna"); // return false
    IsFileBelongToFolderName(filePath,"welcome.jpg"); // return false
