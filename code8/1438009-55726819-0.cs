[HttpGet]
public IActionResult Get()
{        
    return PhysicalFile(@"E:\\Test.jpg", "image/jpeg");
}
- A nice single liner that handles things like 206 partial.
Suggested by Tseng (using an overload of the FileContentResult constructor that accepts a stream):
[HttpGet]
public IActionResult Get()
{        
    FileStream stream = File.Open(@"E:\\Test.jpg");
    return File(stream, "image/jpeg");
}
- Useful if your stream is coming from somewhere else (like an embedded resource).
For RL remember to check the file/resource exists, and return 404 if not.
