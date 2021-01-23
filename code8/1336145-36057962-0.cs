    public class Student
    {
        public long StudentId { get; set; }
        public StudentDetails details { get; set; }
    }
    
        public class StudentDetails
        {
            public long StudentId { get; set; }
            public Student student{ get; set; }
            //other properties
        }
    
    public StudentMapping()
        {
            this.ToTable("Student");
    
            this.HasKey(x => x.StudentId);
    
            this.HasRequired(x => x.details)
                .WithRequiredDependent(x => x.student)
                .WillCascadeOnDelete(true);
        }
    
        public StudentDetailsMapping()
        {
            this.ToTable("StudentDetails");
    
            this.HasKey(x => x.StudentId);
    
            this.HasRequired(x => x.student);
        }
