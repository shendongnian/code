       class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; } 
        }
    
        class Teacher
        {
    
            public string FirstName { get; set; }
            public string LastName { get; set; } 
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var listA = from s in new List<Student>()
                            select new { FirstName = s.FirstName, LastName = s.LastName };
    
                var listB = from t in new List<Teacher>()
                            select new { FirstName = t.FirstName, LastName = t.LastName };
                
                var teachersAndStudents = listA.Concat(listB); 
                var someName = teachersAndStudents.First().FirstName;
            }
        }
