    [HttpPut]
    public async Task<IHttpActionResult> RemoveUserFromGroup(String key, [FromBody]User user)
    {
        Conversation conver = await db.Conversations.FindAsync(key);
        if (conver == null)
        {
              return NotFound();
        }
            
        IEnumerable<User> del = from d in conver.Users
                                where d.Email == user.Email
                                select d;
        conver.Users.Remove(del.ToList()[0]);
            
        await db.SaveChangesAsync();
        return Ok(conver);
    }
