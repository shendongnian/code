    public IHttpActionResult GetMember(int id)
    {
        Member member = null; 
    
        if(id == 0)
        {
            member = new Member();
            // Set default member values here
            // member.MemberId = 123456;
            // member.Name = "My Name";
            // set other default property values.......
            
            db.Members.Add(member);
            db.SaveChanges();  
        }
        else
        {
            member = db.Members.Where(m => m.MemberId == id).FirstOrDefault();
        }
        
        if (member == null)
            return NotFound();
        
        return Ok(member);
    }
