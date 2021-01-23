     DateTimeOffset dto = DateTimeOffset.Parse("2016-02-14T23:30:58Z");
     DateTime dt = dto.UtcDateTime;
---
    [HttpGet("/resource")]
    public IActionResult GetResource([FromQuery]DateTimeOffset? at = null)
    {
        if (!at.HasValue)
        {
            at = DateTimeOffset.UtcNow;
        }
    
        // ...
    }
