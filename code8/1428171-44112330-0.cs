    [HttpGet("test")]
    public async Task<FileResult> Get()
    {
    	var contentRootPath = _hostingEnvironment.ContentRootPath;
    	
        // "items" is a List<T> of DataObjects
    	var items = await _mediator.Send(new GetExcelRequest());
    
    	var fileInfo = new ExcelFileCreator(contentRootPath).Execute(items);
    	var bytes = System.IO.File.ReadAllBytes(fileInfo.FullName);
    
    	const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    	HttpContext.Response.ContentType = contentType;
    	HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
    
    	var fileContentResult = new FileContentResult(bytes, contentType)
    	{
    		FileDownloadName = fileInfo.Name
    	};
    
    	return fileContentResult;
    }
