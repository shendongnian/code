    using SchoolManagementSystem;
    using System;
    using System.Reactive.Linq;
    
    namespace Client
    {
        class Program
        {
            static void Main(string[] args)
            {
                var school1 = new School("School 1");
                var school2 = new School("School 2");
                var school3 = new School("School 3");
    
                var observable = school1
                    .Merge(school2)
                    .Merge(school3);
    
                var subscription = observable
                    .Subscribe(PrintStudentAdmittedMessage, PrintNoMoreStudentsCanBeAdmittedMessage);
    
                school1.FillWithStudents(100);
                school2.FillWithStudents(102);
                school3.FillWithStudents(101);
                
                Console.WriteLine("Press any key to stop observing and to exit the program.");
                Console.ReadKey();
                subscription.Dispose();
            }
    
            static void PrintStudentAdmittedMessage(Student student)
            {
                Console.WriteLine($"Student admitted: {student}");
            }
    
            static void PrintNoMoreStudentsCanBeAdmittedMessage()
            {
                Console.WriteLine("No more students can be admitted.");
            }
        }
    }
