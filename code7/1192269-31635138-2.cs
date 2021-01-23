    static List<string> GetStudentInformation()
        {
             List<string> studentInformation = new List<string>();
             
             //first name
             Console.WriteLine("Enter the student's first name: "));
             studentInformation.Add(Console.ReadLine());
             
             //last name
             Console.WriteLine("Enter the student's last name: "));
             studentInformation.Add(Console.ReadLine());
             
             //more
             return studentInformation;
        }
        
        static void PrintStudentDetails(List<string> studentInformation)
        {
             foreach (string info in studentInformation)
             {
                  Console.WriteLine("{0}", info);
             }
        }
        
        public static void Main (string[] args)
        {
             List<string> studentInformation = GetStudentInformation();
             PrintStudentDetails(studentInformation);
        }
