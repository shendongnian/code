     public class Image
        {
        
          private IHostingEnvironment _hostingEnv;
          public Image(IHostingEnvironment hostingEnv)
          {
             _hostingEnv = hostingEnv;
          }
        
          [HttpPost]
          public async Task<IActionResult> UploadImage(UploadImage model, IFormFile ImageFile)
          {
            if (ModelState.IsValid)
             {
            var filename = ContentDispositionHeaderValue.Parse(ImageFile.ContentDisposition).FileName.Trim('"');
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", ImageFile.FileName);
            using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
             {
                await ImageFile.CopyToAsync(stream);
             }
              model.ImageFile = filename;
             _context.Add(model);
             }        
          }        
        }
