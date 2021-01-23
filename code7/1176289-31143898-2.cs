            int user, pass;
            do
            {
                Console.WriteLine("Enter the username");
                try
                {
                    user = Convert.ToInt32(Console.ReadLine());// it will not be initialized if process fails.
                    pass = Convert.ToInt32(Console.ReadLine());// it will not be initialized if process fails.
                }
                catch (FormatException)
                {
                    // what is user and pass?
                    Console.WriteLine("Invalid Format");
                }
                catch (OverflowException)
                {
                    // what is user and pass?
                    Console.WriteLine("Overflow");
                }
            } while (user != 12 && pass != 1234);
