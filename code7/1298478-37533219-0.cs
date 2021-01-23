    [HttpGet("{key}")]
    public IActionResult Get(string key)
    {
        var file = _files.GetPath(key);
        var result = PhysicalFile(file.Path, "text/text");
        Response.Headers["Content-Disposition"] = new ContentDispositionHeaderValue("attachment")
        {
            FileName = file.Name
        }.ToString();
        return result;
    }
