    public class StudentTest
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Amy Lee", Student.GenerateNextID());
            Student student2 = new Student("John Williams", Student.GenerateNextID());
            Console.WriteLine(student1);
            Console.WriteLine(student2);
            Console.WriteLine("\nPress any key to exit program");
            Console.ReadKey();
        }
    }
