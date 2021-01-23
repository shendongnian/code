        static void Main(){
            bool flag0 = true; //initialize tracking bool value to exit loop when needed
            int result;
            Console.WriteLine("Welcome to our Multiplex");
            Console.WriteLine("We are presently Showing:");
            Console.WriteLine("1.Legend");
            Console.WriteLine("2.Macbeth");
            Console.WriteLine("3.Everest");
            Console.WriteLine("4.A Walk In the Woods");
            Console.WriteLine("5.Hotel Transylvania");
            do //do while loop suits the case the most as it does check the value on the end
            {
                Console.WriteLine("Enter the number of the film you wish to see?");
                string moviestring = Console.ReadLine();
                int.TryParse(moviestring, out result); //does try-catch check so it wont crash on the run-time
                if (result <= 5 && result >= 1) //logical check if value is correct
                    flag0 = false; //exits the loop
                //do true logic....
                else
                    Console.WriteLine("Incorrect value. Try again.");
                //do false logic
                
            } while (flag0);
       }
