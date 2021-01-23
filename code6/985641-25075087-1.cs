    int SaveFile(string filePath)
          {            
                   
            if (!System.IO.File.Exists(filePath)) 
            {
                try{
                    FileUpload1.SaveAs(savePath);
                    return 1;
                }
                catch{
                
                } 
               
              return 0;
            }
           
    
          }
