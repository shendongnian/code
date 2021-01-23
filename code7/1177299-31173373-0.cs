    public ActionResult ListClubMembershipType(int clubId)
    {
      
      var types = from s in db.MembershipTypes
                  where (s.ClubId == clubId)
                  orderby s.Type
                  select s;
      var model = types.Select(t => new ListMembershipTyp‌​eViewModel
      {
        Type = t.Type,
        ClubId = clubId
      });
      return View(model);    
    }
