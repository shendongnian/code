    using (var context = new AbilityDbContext())
    {
        var teacher = context.Teachers.Find(1);
        teacher.Skills = teacher.Skills ?? new List<Skill>();
        teacher.Skills.Add(context.Skills.Find(1));
        teacher.Skills.Add(context.Skills.Find(2));
        context.SaveChanges();
    }
