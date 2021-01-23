    I believe you just want to create a file, download it and then delete it once it has downloaded.
    
    1. Create a custom FileHttpResponseMessage.
      
    
          public class FileHttpResponseMessage : HttpResponseMessage
            {
                private readonly string filePath;
        
                public FileHttpResponseMessage(string filePath)
                {
                    this.filePath = filePath;
                }
        
                protected override void Dispose(bool disposing)
                {
                    base.Dispose(disposing);
                    Content.Dispose();
                   if(File.Exist(filePath))
                    File.Delete(filePath);
               }
            }
    
    2. Create a function which will return generated file path. and use that path in below code :  
    
    public HttpResponseMessage Get()
        {
            var filePath = GetNewFilePath();//your function which will create new file.
            var response = new FileHttpResponseMessage(filePath);
            response.StatusCode = HttpStatusCode.OK;
            response.Content = new StreamContent(new FileStream(filePath, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName ="YourCustomFileName"
            };
            return response;
        }
    
    3. Above code will delete file automatically once file will be served to user.
