    public static Teacher LoadTeacher(int teacherID)
    {
        using (var context = new SchoolContext())
        {
            return context.Teachers.Where(t => t.ID == teacherID)
                                    .Select(t => new Teacher() { Name = t.Name })
                                    .FirstOrDefault();
        }
    }
