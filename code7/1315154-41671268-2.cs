     public class Image
        {
        
          private IHostingEnvironment _hostingEnv;
          public Image(IHostingEnvironment hostingEnv)
          {
             _hostingEnv = hostingEnv;
          }
        
          [HttpPost]
          public IActionResult UploadImage(UploadImage model, IFormFile ImageFile)
          {
            if (ModelState.IsValid)
             {
            var filename = ContentDispositionHeaderValue.Parse(ImageFile.ContentDisposition).FileName.Trim('"');
            var targetDirectory = Path.Combine(_hostingEnv.WebRootPath, string.Format("Common\\Images\\"));
            var savePath = Path.Combine(targetDirectory, filename);
            ImageFile.CopyTo(new FileStream(savePath, FileMode.Create));
            model.ImageFile = filename;
            _imageUploadAppService.UserCreate(model);
             }        
          }        
        }
