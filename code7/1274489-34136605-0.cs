    //namespace can not start with a number
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                //You need to define the list in your host program, not inside the class itself    
                List<StudentClass> ListOfStudents = new List<StudentClass>();
                ListOfStudents.Add(new StudentClass("Jane"));
                ListOfStudents.Add(new StudentClass("Alex"));
                ListOfStudents.Add(new StudentClass("Mike"));
                ListOfStudents.Add(new StudentClass("James"));
                ListOfStudents.Add(new StudentClass("Julia"));
    
  
                ListOfStudents.ForEach(i => Console.WriteLine("{0}", i.GetName()));
                Console.WriteLine("\r\nPress any key to continue...");
                Console.ReadKey();
    
            }
        }
    
        //changed the class to public so you can access it.
        public class StudentClass
        {
            private string _storedStudentName;
    
            public string GetName()
            {
                return _storedStudentName;
            }
    
            public StudentClass(string studentName)
            {
                _storedStudentName = studentName;
            }
        }
    }
