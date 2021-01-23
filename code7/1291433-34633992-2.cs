    public List<CandidateBySkillDTO> getCandidate() 
    {
       return db
          .vSkillMatches
          .Select(e => new 
          {
              candidateInfo = db.Candidates.FirstOrDefault( c => c.Id == e.candidateId),
              skillInfo = db.Skills.FirstOrDefault(s => s.Id == e.skillId)
          })
          .Select(e => new CandidateBySkillDTO
          {
              candidateId = e.candidateInfo.Id,
              candidateMobile = e.candidateInfo.PrimaryMobile,
              SkillName = e.skillInfo.SkillName
          })
          .ToList();
    }
