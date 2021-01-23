        public static void runUpdater()
        {
            int count = 0;
            while (true)
            {
                    WriteToConsole("Doing stuff.... Loop# " + count.ToString());
                    for (int step = 0; step <= int.MaxValue; step++)
                    {
                        if (!breakCurrentOperation())
                        {
                            WriteToConsole("Performing step #" + step.ToString());
                            if (step == int.MaxValue)
                            {
                                step = 0; // Re-set the loop counter
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    count++;
                    if (!startNewOperation())
                    {
                        // Noop
                    }
                    else
                    {
                        break;
                    }
                    
            }
            WriteToConsole("\nAre you ready to run the   database updater again? y/n");
            startApplication(ReadFromConsole());
        }
        public static bool startNewOperation()
        {
            WriteToConsole("Do you want go back to the main menu or start a new update process?  \nType y to start a new update process or n to go to the main menu.");
            string input = ReadFromConsole();
            if (input == "y" || input == "Y")
            {
                return false;
            }
            else if (input == "n" || input == "N")
            {
                return true; // Noop - Restart the Loop from the begining
            }
            else
            {
                WriteToConsole("Error: Input was not recognized. ");
                return startNewOperation(); // Recursivly call method untill user enters a logical input
            }
        }
        public static bool breakCurrentOperation()
        {
            if (Console.KeyAvailable)
            {
                var consoleKey = Console.ReadKey(true);
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    WriteToConsole("Do you want to stop the current process? \nType s to stop or c to continue.");
                    string input = Console.ReadLine();
                    if (input == "c" || input == "C")
                    {
                        return false; // Continue 
                    }
                    else if (input == "s" || input == "S")
                    {
                        return true; // Break the loop
                    }
                    else
                    {
                        WriteToConsole("Error: Input was not recognized, the current process will now continue. Press Esc to stop the operation.");
                    }
                }
            }
            return false;
        }
