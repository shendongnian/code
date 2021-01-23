    [Table("Student", Schema = "School")]
    public class Student
    {
        [Key,Column("Student_ID")]
        public long ID { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
        //...
    }
    [Table("Teacher", Schema = "School")]
    public class Teacher
    {
        [Key,Column("Teacher_ID")]
        public long ID { get; set; }
        public virtual List<Student> Students { get; set; }
        //...
    }
        
    public StudentMap()
    {
       HasMany(p => p.Teachers)
       .WithMany(p => p.Students)
       .Map(m =>
           {
             m.ToTable("StudentsTeachers", "School");
             m.MapLeftKey(p => p.ID);
             m.MapRightKey(p => p.ID);
           });
    }
