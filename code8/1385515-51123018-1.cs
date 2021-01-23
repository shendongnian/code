    public IActionResult Get(IFileProvider fileProvider)
     {
          IDirectoryContents contents = fileProvider.GetDirectoryContents("wwwroot/updates");
    
          var lastUpdate =
                    contents.ToList()
                    .OrderByDescending(f => f.LastModified)
                    .FirstOrDefault();
    
          return Ok(lastUpdate?.Name);
     }
