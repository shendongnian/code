    public IHttpActionResult GetMember(int id)
    {
        Member member = db.Members.Find(id);
        if (member == null)
        {
            if (id != 0)
            {
                member = new Member();
            }
            else
            {
                return NotFound();
            }
        }
        return Ok(member);
    }
