    [HttpPost("upload")]
    public async Task<IActionResult> UploadAsync(CancellationToken cancellationToken)
    {
        if (!Request.HasFormContentType)
            return BadRequest();
        var form = Request.Form;
        foreach(var formFile in form.Files)
        {
            using(var readStream = formFile.OpenReadStream())
            {
                // Do something with the uploaded file
            }
        }
        
        return Ok();
    }
