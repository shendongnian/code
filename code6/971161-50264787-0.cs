    public FileResult DownloadExcel(string filepath) 
    { 
    byte[] fileBytes = System.IO.File.ReadAllBytes(filepath); 
       return   File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet,
                 `enter code here`Path.GetFileName(filepath)); 
    }
    
    ------------------------------------------------------------------------
