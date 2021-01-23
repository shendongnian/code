    class Student
    {
    
    string firstName;
    DateTime birthDay;
    
    
        public void GetStudentInformation()
        {
            Console.WriteLine("Enter student's first name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter student's birth date: ");
            
            birthDay = DateTime.Parse(Console.ReadLine());
        }
        public void PrintStudentData()
        {
            Console.WriteLine("Student {0} was born in {1}", firstName, birthDay);
        }
    }
    class Program
    {
        static void Main(string[] args)
        { 
    	    var myStudent = new Student();
            myStudent.GetStudentInformation();
            myStudent.PrintStudentData();
        }
    }
