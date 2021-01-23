    public IHttpActionResult GetConversationForUser(String email)
    {
    
        IQueryable<Conversation> users = from d in db.Conversations
                                         where d.Users.Any(u=>u.Email== email)
                                         select d; 
    
        if(!users.Any())
        {
           return NotFound();
        }
    
        return Ok();
    }
