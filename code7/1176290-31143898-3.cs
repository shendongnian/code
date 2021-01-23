            int user, pass;
            do
            {
                Console.WriteLine("Enter the username");
                user = Convert.ToInt32(Console.ReadLine()); // it will be initialized any way.
                pass = Convert.ToInt32(Console.ReadLine()); // it will be initialized any way.
                
            } while (user != 12 && pass != 1234);
