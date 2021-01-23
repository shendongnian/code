    public FileDetails UploadSingle(IFormFile file)
    {
        FileDetails fileDetails;
        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            var fileContent = reader.ReadToEnd();
            var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            fileDetails = new FileDetails
            {
                Filename = parsedContentDisposition.FileName,
                Content = fileContent
            };
        }
    
        return fileDetails;
    }
    [HttpPost]
    public async Task<IActionResult> UploadMultiple(ICollection<IFormFile> files)
    {
        var uploads = Path.Combine(_environment.WebRootPath,"uploads"); 
        foreach(var file in files)
        {
            if(file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                await file.SaveAsAsync(Path.Combine(uploads,fileName));
            }
        return View();
        }
    }    
