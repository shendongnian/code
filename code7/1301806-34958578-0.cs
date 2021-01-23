    using System.IO
   
    string FolderLocation = @"c:\MyFolder";
    public void DeleteItemFile(string FileName){
        string fileLPath = Path.Combine(FolderLocation,FileName);
        File.Delete(filePath);
    
    
    }
