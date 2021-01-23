            int user, pass;
            do
            {
                Console.WriteLine("Enter the username");
                try
                {
                    user = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the password");
                    pass = Convert.ToInt32(Console.ReadLine());
                    if (user == 12 && pass == 1234)
                        Console.WriteLine("Correct");
                    else
                        Console.WriteLine("Invalid Username or Password");
                    Console.ReadKey();
                }
                catch (FormatException)
                {
                    user = 0;
                    pass = 0;
                    Console.WriteLine("Invalid Format");
                }
                catch (OverflowException)
                {
                    user = 0;
                    pass = 0;
                    Console.WriteLine("Overflow");
                }
            } while (user != 12 && pass != 1234);
