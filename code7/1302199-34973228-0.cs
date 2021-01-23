        static void Main(string[] args)
        {
            // First you need a few loops, avoid goto's at all costs they make code much harder to read
            // There are better ways to do this but this will get it done
            // List<string> answer = new List<string>(); would be better here because it resizes automatically when adding
            // I left it like this because it looks like a school project
            List<string> answer = new List<string>(); // create variable before loops so it is not recreated on each iteration
            bool exit = false; // create bool variable and use it to exit infinite loop by setting it to true when user chooses option 4
            
            for (;;) // create outer infinit loop  to so the code will execute until you want you break; when option 4 is entered
            {
                int option;
                for (;;)// create infinite loop to get user input for which option they want
                {
                    Console.Clear();
                    Console.WriteLine("Enter the options given below\n1.Add students\n2.View all details\n3.Sorting\n4.Exit\n");
                    if (int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 4)
                    { break; /*user entered valid option so we break from this infinit loop*/ }
                    else
                    { Console.Clear(); /*User did not enter a valid option so clear the console window*/ }
                }
                switch (option) // switch cases to handle each of the possible options entered
                {
                    case 1:
                        // user chose option 1
                        int number = 0;
                        while (number <= 0)
                        {
                            Console.Clear();
                            
                            Console.WriteLine("Enter the number of students to add.");
                            int.TryParse(Console.ReadLine(), out number);
                            // Because "answer" is now a list it does not have to be sized
                            for(int i=0;i<number;i++)
                            {
                                Console.Clear();
                                Console.WriteLine("Enter Name: ");
                                // with a list, the previous list of students are not wiped out
                                // we also don't have to be carefull about writing outside array bounds because of the add method
                                answer.Add(Console.ReadLine());
                            }
                        }
                
                        break; // break out of case 1
                    case 2:
                        // user chose option 2
                        break;// break out of case 2
                    case 3:
                        // user chose option 3
                        if (answer.Count > 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Sorted student names:");
                            answer.Sort(); // List<string> have a Sort member method
                            Console.WriteLine(string.Join("\n", answer));
                        }
                        else
                        { Console.WriteLine("No students exist to sort or list."); }
                        Console.ReadLine(); // pause screen for reading
                        break;// break out of case 3
                    case 4:
                        // user chose option 4
                        while (true) // loop until a Y or 1 is entered
                        {
                            Console.WriteLine("Are you sure you want to exit\nY for YES and 1 for NO");
                            char y = (char)Console.Read();
                            if (y == 'Y' || y == 'y')
                            { exit = true; break; /*user is sure they want to exit*/ }
                            else if (y == '1')
                            { Console.Clear(); break; /*user decided not to exit*/  }
                            else
                            { Console.Clear(); }
                        }
                        break; // break out of case 4
                        
                }
                if (exit) break; // if exit variable true then break out of outer infinite loop
            }
        }
