    public ActionResult SendVote(bool vote)
    {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<VoteLogViewModel, VoteLog>());
        var mapper = config.CreateMapper();
    
        if(!ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }
        if(vote)
        {
            //Send to db
            VoteLogViewModel voteLogViewModel = new VoteLogViewModel
            {
                DateAdded = DateTime.Now,
                Id = Guid.NewGuid().ToString(),
                PlaceId = id,
                UserId = User.Identity.GetUserId(),
                Vote = 1
            };
            db.VoteLogs.Add(mapper.Map<VoteLog>(voteLogViewModel));
            db.SaveChanges();
        }
        else
        {
         //Send to db
        }
    
        return new EmptyResult();
    }
