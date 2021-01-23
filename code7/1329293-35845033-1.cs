        File oldestFile = YourList.OrderBy(l =>l.CreationDate)
                                  .FirstOrDefault();// getting oldest file
        
        string extension = System.IO.Path.GetExtension(string oldestFile.FileName);//take extension
    
        string Rename = "new name " + extension;//concanate new name and extension
    
        YourList.OrderBy(l =>l.CreationDate)
               .Select(l =>  l.FileName)
               .FirstOrDefault().FileName = Rename; // update new name 
