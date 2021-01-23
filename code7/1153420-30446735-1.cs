    private static YourContext GetContext()
    {
        return new YourContext();//Change as needed.
    }
    
    
    public async Task<ActionResult> Load()
    {
        using(var db1 = GetContext())
        using(var db2 = GetContext())
        using(var db3 = GetContext())
        {
            var housing = db1.Housing.ToListAsync();
            var school = db2.Schools.ToListAsync();
            var projects = db3.Projects.ToListAsync();
        
            await Task.WhenAll(housing, school, projects);
        
            var vm = new ItemViewModel
            {
                HousingTotals = await housing,
                SchoolTotals = await school,
                ProjectTotals = await projects
            };
        
            return PartialView(vm);
        }
    }
