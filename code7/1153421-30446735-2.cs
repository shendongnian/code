    public async Task<ActionResult> Load()
    {
        var housing = await _db.Housing.ToListAsync();
        var school = await _db.Schools.ToListAsync();
        var projects = await _db.Projects.ToListAsync();
    
    
        var vm = new ItemViewModel
        {
            HousingTotals = housing,
            SchoolTotals = school,
            ProjectTotals = projects
        };
    
        return PartialView(vm);
    }
