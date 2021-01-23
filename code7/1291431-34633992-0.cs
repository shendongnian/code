    public List<CandidateBySkillDTO> getCandidate() 
    {
       return db
          .vSkillMatches
          .Select(e => new 
          {
              candidateInfo = db.Candidates.Find(e.candidateId),
              skillInfo = db.Skills.Find(e.skillId);
          })
          .Select(e => new CandidateBySkillDTO
          {
              candidateId = e.candidateInfo.Id,
              candidateMobile = e.candidateInfo.PrimaryMobile,
              SkillName = e.skillInfo.SkillName
          })
          .ToList();
    }
