    static string GetStudentInformation()
    {
         Console.WriteLine("Enter the student's first name: ");
         return Console.ReadLine();
    }
    
    static void PrintStudentDetails(string first)
    {
         Console.WriteLine("{0}", first);
    }
    
    public static void Main (string[] args)
    {
         string firstName = GetStudentInformation();
         PrintStudentDetails(firstName);
    }
