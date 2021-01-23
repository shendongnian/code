    public static dynamic firstName;
        public static dynamic lastName;
        public static dynamic birthday;
    static void Main(string[] args)
    {
       
        getUserInformation();
        printStudentDetails(firstName, lastName, birthday);
    }
    static void getUserInformation()
    {
        Console.WriteLine("Enter the student's first name: ");
        firstName = Console.ReadLine();
        Console.WriteLine("Enter the student's last name");
        lastName = Console.ReadLine();
        Console.WriteLine("Enter your bithdate");
        birthday = Console.ReadLine();
    }
    static void printStudentDetails(string firstName, string lastName, string birthday)
    {
        Console.WriteLine("{0} {1} was born on: {2}", firstName, lastName, birthday);
        Console.ReadLine();
    }
