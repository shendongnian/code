     class Student
        {
            public string FirstName {get;set;}
            public string LastName {get;set;}
        }
    
    static Student GetStudentInformation()
        {
             Student student = new Student();
             
             //first name
             Console.WriteLine("Enter the student's first name: "));
             student.FirstName = Console.ReadLine();
             
             //last name
             Console.WriteLine("Enter the student's last name: "));
             student.LastName = Console.ReadLine();
             
             //more
             return student;
        }
        
        static void PrintStudentDetails(Student student)
        {
            Console.WriteLine("{0}", student.FirstName);
            Console.WriteLine("{0}", student.LastName);
        }
        
        public static void Main (string[] args)
        {
             Student student = GetStudentInformation();
             PrintStudentDetails(student);
        }
