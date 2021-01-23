    public void AddOrUpdate(Student student)
    {
        using (var context = new DBContext())
        {
            context.Student.AddOrUpdate(student);
            context.SaveChanges();
        }
    }
