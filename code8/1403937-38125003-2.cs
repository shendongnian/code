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
        
        foreach(Student s in StudentsClassCollection)
        {
           if(s.StudentName.Equals("what you looking for"))
              s.Passed = true;
        }
