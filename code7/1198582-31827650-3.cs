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
                employees = genericMethodClass.SortArrayOfObjects<EmployeeInfo>(employees, "FirstName", "ASC");
                students = genericMethodClass.SortArrayOfObjects<Student>(students, "StudentName", "ASC");
                foreach (var employee in employees.Cast<EmployeeInfo>())
                    Console.WriteLine(employee.FirstName);
                Console.WriteLine();
                foreach (var Student in students.Cast<Student>())
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
