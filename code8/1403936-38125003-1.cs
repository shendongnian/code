        public List<Student> StudentsClassCollection = new List<Students>();
        StudentsClassCollection.Add(new Student("Ben","true"))
        
        public class Student
        {
            public string StudentName {get; set;}
            public bool Passed { get; set;}
    
            public Student(string name,Bool pass)
            {
               this.StudentName = name;
               this.Passed = pass;
            }
        }
        
        StudentsClassCollection[0].StudentName = "Danny";
