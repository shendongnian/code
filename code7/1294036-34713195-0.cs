    public void Update(Timesheet timesheet)
    {
        var existingParent = _dbContext.Parents
            .Where(p => p.Id == timesheet.Id)
            .Include(p => p.TimesheetLines)
            .SingleOrDefault();
    
        if (existingParent != null)
        {
            // Update parent
            _dbContext.Entry(existingParent).CurrentValues.SetValues(timesheet);
    
            // Delete TimesheetLines
            foreach (var existingChild in existingParent.TimesheetLines.ToList())
            {
                if (!timesheet.TimesheetLines.Any(c => c.Id == existingChild.Id))
                    _dbContext.TimesheetLines.Remove(existingChild);
            }
    
            // Update and Insert TimesheetLines
            foreach (var childtimesheet in timesheet.TimesheetLines)
            {
                var existingChild = existingParent.TimesheetLines
                    .Where(c => c.Id == childtimesheet.Id)
                    .SingleOrDefault();
    
                if (existingChild != null)
                    // Update child
                    _dbContext.Entry(existingChild).CurrentValues.SetValues(childtimesheet);
                else
                {
                    // Insert child
                    var newChild = new Child
                    {
                        Data = childtimesheet.Data,
                        //...
                    };
                    existingParent.TimesheetLines.Add(newChild);
                }
            }
    
            _dbContext.SaveChanges();
        }
    }
