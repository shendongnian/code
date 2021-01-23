    class Employee
    {
         // Existing code above this
         public bool Authenticate() 
         {
             var authed = false;
             do
             {
                 Console.Write("Username: ");
                 var attemptUsername = Console.ReadLine();
                 Console.Write("Password: ");
                 var attemptPassword = Console.ReadLine();
                 if (username != attemptUsername || password != attemptPassword)
                 {
                     Console.WriteLine("Incorrect Username or Password. Please Try again \n");
                 }
                 else 
                 {
                     authed = true;
                 }
             }
             while (!authed);
             Console.Clear();
             Console.Write("Login Sucessful!. Press any key to continue...");
             Console.ReadKey();
             return true;
         }
    }
