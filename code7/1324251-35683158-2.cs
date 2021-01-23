    static void Main()
    {
        Student newStudent = new Student();
        newStudent.GetStudentInformation();
        newStudent.PrintStudentData(ref Student.birthDay);
        Console.ReadKey();
        logEnd();
    }
    class Student
    {
        static public DateTime birthDay;
        public void GetStudentInformation()
        {
            Console.WriteLine("Enter student's birth date as day/month/year");
            string[] formats = { "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                    "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy"};
            while (!DateTime.TryParseExact(Console.ReadLine(), formats,
                 System.Globalization.CultureInfo.InvariantCulture,
                 System.Globalization.DateTimeStyles.None,
                 out birthDay))
            {
                Console.WriteLine("Your input is incorrect. Please input again.");
            }
           
            // User input correct, birthDay can now be used
            
        }
        public void PrintStudentData(ref DateTime birthDay)
        {
            Console.WriteLine("Student was born in {0}", birthDay.ToString("dd.MM.yyyy"));
        }
    }
