    static void GetStudentInformation(out string firstName, out string lastName, out DateTime birthDate,
        out string add1, out string add2, out string city, out string state, out int zip, out string country)
    {
        Console.WriteLine("Enter the student's first name: ");
        firstName = Console.ReadLine();
        Console.WriteLine("Enter the student's last name: ");
        lastName = Console.ReadLine();
        Console.WriteLine("Enter the student's birthdate: ");
        birthDate = Convert.ToDateTime(Console.ReadLine());
        Console.WriteLine("Enter the student's address line 1: ");
        add1 = Console.ReadLine();
        Console.WriteLine("Enter the student's address line 2: ");
        add2 = Console.ReadLine();
        Console.WriteLine("Enter the student's city: ");
        city = Console.ReadLine();
        Console.WriteLine("Enter the student's state: ");
        state = Console.ReadLine();
        Console.WriteLine("Enter the student's zip code: ");
        zip = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the student's country: ");
        country = Console.ReadLine();
    }
    static void PrintStudentDetails(string first, string last, string birthday)
    {
        Console.WriteLine("{0} {1} was born on: {2}", first, last, birthday);
    }
    static void Main(string[] args)
    {
        string firstName, lastName, add1, add2, city, state, country;
        DateTime birthDate;
        int zip;
        GetStudentInformation(out firstName, out lastName, out birthDate, out add1, out add2, out city, out state, out zip, out country);
        PrintStudentDetails(firstName, lastName, birthDate.ToShortDateString());
    }
