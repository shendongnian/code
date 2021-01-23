    public class StudentManager : ManagerBase {
        public StudentManager(IDbContext dbContext, IFactory factories) : base(dbContext, factories) { }
        public Student AddNewStudent(string fName, string lName, DateTime dob) {
            // Create a student model instance using factory
            var record = Factories.StudentFac.Create(r => {
                r.FirstName = fName;
                r.LastName = lName;
                r.DoB = dob;
            });
            base.DbContext.Students.Add(record);
            base.DbContext.SaveChanges();
            return record;
        }
    }
