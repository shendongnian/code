            //Users message
            string usrMsg = null;
            while (true)
            {
                //Menu
                Console.WriteLine(" \n\tWelcome!");
                Console.WriteLine(" \t[1]Store value");
                Console.WriteLine(" \t[2]Write message");
                Console.WriteLine(" \t[3]Clear the console");
                Console.WriteLine(" \t[4SShut down program");
                Console.Write("\tChoose: ");
                //Users choice
                int choice = Convert.ToInt32(Console.ReadLine());
                
                
                //if statement 
                if (choice == 1)
                {
                    usrMsg += Console.ReadLine();
                }
                else if (choice == 2)
                {
                    Console.WriteLine(usrMsg);
                }
                else if (choice == 3)
                {
                    //Shuts down program
                    break;
                }
                else if (choice == 4)
                {
                    //Clear program
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("please enter a number between 1-4");
                }
            }
            
