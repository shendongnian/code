    public IHttpActionResult GetMember(int id)
        {
            Member member = db.Members.Find(id);
            if (id > 0)
            {
                var members = db.Members.Find();
                member = members.FirstOrDefault((m) => m.MemberId == id);
                return Ok(member);
    		}
    		else
    		{
    			// Set some values if you need Ok(new Member { MemberId = 0, FirstName = "New"} ) or add to the database and get the member
    			return Ok(new Member());
    		}
    	}
