    public IHttpActionResult GetMember(int id)
    {
        Member member = db.Members.Find(id);
        if (member == null)
        {
            member = new Member();
        }
        return Ok(member);
    }
