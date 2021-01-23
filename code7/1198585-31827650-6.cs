    namespace GenericMethodApp
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var employees = new object[]
                {
                    new EmployeeInfo { FirstName = "Mohammed" },
                    new EmployeeInfo { FirstName = "Ghasan" }
                };
                var students = new object[]
                {
                    new Student { StudentName = "Mike" },
                    new Student { StudentName = "Harris" }
                };
                var genericMethodClass = new GenericMethodClass();
                
                // Note that the generic method returns the array of the specific type
                // thanks to the T type parameter.
                EmployeeInfo[] returnedEmployees = genericMethodClass.SortArrayOfObjects<EmployeeInfo>(employees, "FirstName", "ASC");
                Student[] returnedStudents = genericMethodClass.SortArrayOfObjects<Student>(students, "StudentName", "ASC");
                foreach (var employee in returnedEmployees)
                    Console.WriteLine(employee.FirstName);
                Console.WriteLine();
                foreach (var Student in returnedStudents)
                    Console.WriteLine(Student.StudentName);
                Console.ReadKey();
            }
        }
        public class EmployeeInfo
        {
            public string FirstName { get; set; }
        }
        public class Student
        {
            public string StudentName { get; set; }
        }
    }
