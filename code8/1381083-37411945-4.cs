    public class Student
    {
        public Student()
        {
            Students= new List<Student>();
        }
    
        public int StundendId{ get; set; }
    
        public string StudentName { get; set; }
    
        public int? SharedStudentId{ get; set; }
    
        [ForeignKey("SharedStudentId")]
        public Student SharedStudent{ get; set; }
    
        public virtual ICollection<Student> SharedStudents{ get; set; }
    }
