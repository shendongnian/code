    public void Configure(..., ..., SchoolContext context)
    {
        ...
        DbInitializer.Initialize(context);
    }
...
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();
            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }
            var students = new Student[]
            {
                new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")}, ...
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();
            ...
