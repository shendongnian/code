	var is28 = ParticipantBaseModel.Is28Expression();
    return new ParticipantsSummary(from p in _dbContext.Participants.AsExpandable()
                                   select new ParticipantStage 
                                   { 
                                      Id = p.Id, 
                                      Arm = p.TrialArm,
                                      Is28 = is28.Invoke(p)
                                   }));
