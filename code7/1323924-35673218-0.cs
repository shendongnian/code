    namespace Uczymy3
    {
        class Student
        {
            private readonly string firstName;
            private readonly DateTime birthDay;
    
            public Student(string firstName, DateTime birthDay)
            {
                this.firstName = firstName;
                this.birthDay = birthDay;
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
                Console.WriteLine("Enter student's first name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter student's birth date: ");
                DateTime birthDay = DateTime.Parse(Console.ReadLine()); /* not really a user friendly way, but ok :) */
    
                Student student = new Student(firstName, birthDay);
                student.PrintStudentData();
            }
        }
    }
