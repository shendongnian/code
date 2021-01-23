    public IHttpActionResult GetConversationForUser(String email)
    {
    
        IQueryable<Conversation> users = from d in db.Conversations
                                         where d.Users.Any(u=>u.Email == email)
                                         select d; 
        //Check if the query returns something not if the query is null, which won't happen 
        if(!users.Any())
        {
           return NotFound();
        }
    
        return Ok();
    }
