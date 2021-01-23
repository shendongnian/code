    namespace Uczymy3
    {
        class Student
        {     
         class StudentInfo{
          string firstName {get; set;}
          DateTime birthDay {get;set;}
         }
            public static StudentInfo GetStudentInformation()
            {
                StudentInfo info = new StudentInfo();
                Console.WriteLine("Enter student's first name: ");
                info.firstName = Console.ReadLine();
                Console.WriteLine("Enter student's birth date: ");
                info.birthDay = DateTime.Parse(Console.ReadLine());
                return info;
            }
            public static void PrintStudentData(StudentInfo info)
            {
                Console.WriteLine("Student {0} was born in {1}", info.firstName, info.birthDay);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var info = Student.GetStudentInformation();
                PrintStudentData(info);
            }
        }
    }
