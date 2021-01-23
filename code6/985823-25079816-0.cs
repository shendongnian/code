                String username;
                String password;
                String[,] accnts = { { "cads123", "dadada" }, { "carladrian", "fafafa" }, { "delossantos", "gagaga" } };
                int row = 0, x = 3;
                bool loggedIn = false;
                do
                {
                    Console.WriteLine("You have " + x + " attempt/s.");
                    Console.Write("Enter Username>> ");
                    username = Console.ReadLine();
                    Console.Write("Enter Password>> ");
                    password = Console.ReadLine();
                    for (row = 0; row < 3; row++)
                    {
                        if (username.Equals(accnts[row, 0]) && password.Equals(accnts[row, 1]))
                        {
                            Console.WriteLine("Welcome " + accnts[row, 0] + "!");
                            loggedIn = true;
                            break;
                        }
                    }
                    if (loggedIn)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input.");
                        if (x != 1)
                        {
                            Console.WriteLine("Please Try Again.");
                            Console.Write("\n");
                        }
                        else if (x.Equals(1))
                        {
                            Console.Write("Goodbye!");
                            break;
                        }
                    }                    
                } while (--x > 0);
