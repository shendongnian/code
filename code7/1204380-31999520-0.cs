                    string name;
                    char CurrentChar = ' ';                    
                    do
                    {
                        CurrentChar = Console.ReadKey().KeyChar;
                        if (CurrentChar != '\b')
                        {
                            name = name + CurrentChar;
                            if (CurrentChar == (char)13)
                            {
                                return name;
                            }
                        }
                        else if (Console.CursorLeft >= 14)
                        {
                            name = name.Remove(name.Length - 1);
                            Console.Write(" \b");
                        }
                        else
                        {
                            Console.CursorLeft = 14;
                        }
                    } while (CurrentChar != (char)27);
