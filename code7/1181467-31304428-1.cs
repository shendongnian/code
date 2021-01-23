    public IHttpActionResult GetMember(int id)
    {
    	Member member = new Member();
    	if (id > 0)
    	{
    		var members = db.Members.Find();
    		member = members.FirstOrDefault((m) => m.MemberId == id);
    	}
    	else
    	{
    		// Set some values if you need Ok(new Member { MemberId = 0, FirstName = "New"} )
    	}
    	
    	return Ok(member);
    }
