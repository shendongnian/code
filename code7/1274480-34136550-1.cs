    class Program
    {
        static void Main()
        {
            var students = Student.GenerateStudents();
            students.ForEach(i => Console.WriteLine("{0}", i.Name));
            Console.WriteLine("\r\nPress any key to continue...");
            Console.ReadKey();
        }
    }
