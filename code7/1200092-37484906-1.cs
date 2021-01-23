    context.Entry(user).State = EntityState.Modified;
    try
    {
        await context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!UserExists(id))
        {
            return NotFound();
        }
        else
        {
            //remove the user we just added, otherwise it will not goto 
            //the database to obtain the updated user
            context.Entry(user).State = EntityState.Detached;
            var updatedUser = await context.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (updatedUser == null)
            {
                return NotFound();
            }
            var returnAction  = CreatedAtAction("PutUser", new { id = user.Id }, updatedUser);
            returnAction.StatusCode = StatusCodes.Status409Conflict;
            return returnAction;                    
        }
    }
