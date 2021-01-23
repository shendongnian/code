    var query =
       from u in ctx.Users
       from uss in u.UserSubSkills
       where uss.Level > 0
       where subSkillsToSearch.Contains(uss.SubSkillId)
       group uss by new 
       { 
         u.ID, 
         UserName = u.Name, 
         SkillName = uss.SubSkill.Skill.Name 
       } into uss
       select new
       {
         User = uss.Key.UserName,
         Skill = uss.Key.SkillName,
         SubSkillAndLearningList = uss.Select(x => x.SubSkill.Name + " (" + x.Level + ")")
                                      .ToList()
       };
