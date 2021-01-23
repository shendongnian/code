    public ActionResult Action(Guid[] selectedTeamMembers)
    {
    
     
    
        using (var ctx = new DatabaseContext())
        {
    
            //
            // Start by targeting all users!
            //
            var usersToRemove = ctx.Users.AsQueryable();
    
            //
            // if we have specified a selection then select the inverse.
            //
            if (selectedTeamMembers != null)
            {
                usersToRemove = usersToRemove.Where(x => !selectedTeamMembers.Contains(x.Id));
            }
    
    
            //
            // Use the Set Generic as this gives us access to the Remove Range method
            //
            ctx.Set<User>().RemoveRange(usersToRemove);
    
    
            ctx.SaveChanges();
    
        }
    
                
    
        return View();
    }
