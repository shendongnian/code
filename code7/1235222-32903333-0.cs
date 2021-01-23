            int numero1 = 5; //Declaring first variable
            int numero2 = 5; //Declaring second variable
            Console.WriteLine ("What is the answer of " + numero1 + " x " + numero2); //Asking question to the user
            string answer = Console.ReadLine(); //Converting the "answer" to integral variable
                     
            if (answer == "25") //If the answer is 25
            {
                Console.WriteLine("Good answer!"); //This message appears            
            }
            else if (answer == "screw you, don't tell me what to do!") //If the user insult me
            {
                Console.WriteLine("Wow buddy, gotta check that language!"); //The user receives this message              
            }
            else
            {
                Console.WriteLine("Dude...what?"); //If the user write anything else, he gets this message
            }
            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
