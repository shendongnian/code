    var classEntity = testContext.Set<ClassEntity>().Where(t => t.Id == classId);
    var classes = classEntity.ToList().Select(c =>
    {
        testContext.Entry(c)
        .Collection(p => p.Students)
        .Query()
        .Where(s => s.Gender == GenderEnum.Male)
        .Load();
        return c;
    });
