    public static string LoadTeacher(int teacherID)
    {
        using (var context = new SchoolContext())
        {
            return context.Teachers.Where(t => t.ID == teacherID).Select(t => t.Name)
                                    .FirstOrDefault();
        }
    }
