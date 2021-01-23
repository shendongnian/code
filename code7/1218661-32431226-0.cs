    Console.WriteLine("Enter Age : ");
                ConsoleKeyInfo key;
                string ageStr = "";
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        if (char.IsNumber(key.KeyChar))//Check if it is a number
                        {
                            ageStr += key.KeyChar;
                            Console.Write(key.KeyChar);
                        }
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && ageStr.Length > 0)
                        {
                            ageStr = ageStr.Substring(0, (ageStr.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
    
                } while (key.Key != ConsoleKey.Enter);
    
                Console.WriteLine("Age is {0}", ageStr);
