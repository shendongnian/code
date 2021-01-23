    [HttpPost]
    public Task<IActionResult> Upload(IFormFile file) {
        FileDetails fileDetails = null;
        using (var reader = new StreamReader(file.OpenReadStream())) {
            var fileContent = reader.ReadToEnd();
            ContentDispositionHeaderValue parsedContentDisposition = null;
            if (ContentDispositionHeaderValue.TryParse(file.ContentDisposition, out parsedContentDisposition)) {
                fileDetails = new FileDetails {
                    Filename = parsedContentDisposition.FileName,
                    Content = fileContent
                };
            }
        }
        return Task.FromResult((IActionResult)fileDetails);
    }
