    public class Standard
    {
        public Standard()
        {
    
        }
        public int StandardId { get; set; }
        public string StandardName { get; set; }
            
        public int StudentID{get;set;}//foreign key references Student(StudentID)
        public virtual ICollection<Student> Students { get; set; }
    }
