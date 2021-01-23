    static void Main(string[] args)
        {
            demo obj = new demo();
            string uname, pass;
            Console.ForegroundColor = ConsoleColor.Green;
        label1:
            Console.Clear();
            Console.WriteLine("Enter username");
            uname = Console.ReadLine();
            Console.WriteLine("Enter Password");
           bool SuccessfulPassword = false;
           int AttemptsLeft = 5;
            while(!SuccessfulPassword && AttemptsLeft > 0){
            pass = Console.ReadLine();
            obj.setName(uname);
            obj.setPass(pass);
            if (obj.getName() == "niit")
            {
                if (obj.getPass() == "1234")
                {
                    Console.WriteLine("welcome");
                    SuccessfulPassword = true;
                }
            }
            else
            {
                AttemptsLeft--;
                Console.Clear();
                Console.WriteLine("Invalid");
                Console.WriteLine("\n \n \n To try again enter y");
                int n = 5;
                string yes = Console.ReadLine();
                    if (yes == "y")
                {
                   
                        Console.Write(AttemptsLeft + " Tries left");
                }
            }
            Console.ReadKey();
            }
        }
