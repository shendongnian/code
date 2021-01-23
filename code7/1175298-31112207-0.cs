            int number = 0;
            do
            {
                while (!Console.KeyAvailable)
                {
                    string a = Console.ReadLine();
                    bool bWriteNumber = false;
                    try
                    {
                        number = int.Parse(a);
                        bWriteNumber = true;
                    }
                    catch
                    {
                        Console.WriteLine("Sorry! I only accept int");
                    }
                    finally
                    {
                        if (bWriteNumber)
                            Console.WriteLine(number);
                    }
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
