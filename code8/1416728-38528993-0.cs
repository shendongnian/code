     public object Any()
     {
         string fileFullPath = "...";
         string mimeType = "application/pdf";
         FileInfo fi = new FileInfo(fileFullPath);
    
         byte[] reportBytes = File.ReadAllBytes(fi.FullName);
         result = new HttpResult(reportBytes, mimeType);
         result.Headers.Add("Content-Disposition", "attachment;filename=YOUR_NAME_HERE.pdf;");    
         return result;
     }
