    static void Main(string[] args)
    {
         List<User> users = new List<User>();
    
         char createAnotherUser = 'N';
    
         do
         {
              var user = new User();
              int age;
    
              Console.Write("\nUser Name: ");
              user.Name = Console.ReadLine();
    
              Console.Write("Age: ");
              string ageInputString = Console.ReadLine();
    
              //Validate the provided age is Int32 type. If conversion from string to Int32 fails prompt user until you get valid age.
              //You can refactor and extract to separate method for validation and retries etc., as you move forward.
              while (!int.TryParse(ageInputString, out age)) //Notice passing parameter by reference with 'out' keyword and it will give us back age as integer if the parsing is success.
              {
                   Console.Write("Enter a valid Age: ");
                   ageInputString = Console.ReadLine();
              }
    
              //Accept other data you need and validate if required
              users.Add(user); //Add the user to the List<User> defined above
    
              //Confirm if another user to be created
              Console.Write("Do you want to create another User[Y/N]? : ");
              createAnotherUser = char.ToUpper(Console.ReadKey(false).KeyChar); //Compare always upper case input irrespective of user input casing.
    
        } while (createAnotherUser == 'Y');
