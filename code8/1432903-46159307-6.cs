    [HttpGet]
    public async Task<IActionResult> Get([FromForm]bool strip_nulls = true)
    {
        var teams = await _context.Teams.Include(t => t.Games).ToListAsync();
    
        return Json(teams, new JsonSerializerSettings() { 
             NullValueHandling = strip_nulls ? NullValueHandling.Ignore : NullValueHandling.Include,
             ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
    }
