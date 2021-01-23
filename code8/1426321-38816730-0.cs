     public IHttpActionResult Getmember(long id)
            {
                member member = db.members.Find(id);
                if (member == null)
                {
                    return NotFound();
                }
    
                return Ok(member);
            }
