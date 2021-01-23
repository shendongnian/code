    var firstName;
    var lastName ;
 
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
              
    
            }
