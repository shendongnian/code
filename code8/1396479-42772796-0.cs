    public IActionResult About(IList<IFormFile> files)
    {
        foreach (var file in files)
        {
            var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');
            filename = @"C:\UploadsFolder" + $@"\{filename}";
            using (FileStream fs = System.IO.File.Create(filename))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }
        return View();
    }
