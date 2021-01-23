    [HttpGet]
    public async Task<List<Team>> Get([FromForm]bool strip_nulls = true)
    {
        var teams = _context.Teams.AsQueryable();
        teams = teams.Include(t => t.Games).AsNoTracking();
        Teams _return = await teams.ToListAsync();
        return Json(_return, new JsonSerializerSettings() { 
             NullValueHandling = strip_nulls ? NullValueHandling.Ignore : NullValueHandling.Include,
             ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
    }
