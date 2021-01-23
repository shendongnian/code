     class Mainclass
        {
            Main()
            {
               Employee employee1 = new Employee("John", "123");
               employee1.yourMethod();
            }
        
        }   
        
        
       public class Employee
            {
                string username;
                string password;
            .
            .
            .
            public void yourMethod()
            {
                   do
                    {
                        Console.Write("Username: ");
                        username = Console.ReadLine();
                        Console.Write("Password: ");
                        password = Console.ReadLine();
            
                        if (veterinarian1.Username != username || veterinarian1.Password != password)
                        {
                            Console.WriteLine("Incorrect Username or Password. Please Try again \n");
                        }
                    }
                    while (veterinarian1.Username != username || veterinarian1.Password != password);
            
                    Console.Clear();
                    Console.Write("Login Sucessful!. Press any key to continue...");
                    Console.ReadKey();
            }
            
            }
