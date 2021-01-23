    [HttpPost]
    public async Task<string> FileTrs()
    {
         if (Request.Files.Any)
         {
             var file = Request.Files[0];
             if (file != null && file.ContentLength > 0)
             {
                // Unzip file here with for example SharpZipLib
             }
         }
     }
