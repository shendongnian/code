    public void DeleteYogaClasses(Teacher teacher)
    {
        foreach (var yogaClass in teacher.YogaClasses.ToList())
        {
            context.Entry(yogaClass).State = EntityState.Deleted;
        }
        context.SaveChanges();
    }
