    public class Student
    {
        public Student()
        {
    
        }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        
        public int StandartID{get;set;}//foreign key references Standart(StandartId)
        public virtual Standard Standard { get; set; }//navigation property
    }
