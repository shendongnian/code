    using (var context = new AbilityDbContext())
    {
        if (!context.Skills.Any())
        {
            context.Skills.Add(new Skill { SkillName = "C#" });
            context.Skills.Add(new Skill { SkillName = "Java" });
            context.Skills.Add(new Skill { SkillName = "Html" });
            context.Skills.Add(new Skill { SkillName = "Ruby" });
        }
        if (!context.Teachers.Any())
            context.Teachers.Add(new Teacher
            {
                FirstName = "Alberto",
                LastName = "Monteiro",
                Campus = "PICI",
                Email = "alberto.monteiro@live.com"
            });
        context.SaveChanges();
    }
