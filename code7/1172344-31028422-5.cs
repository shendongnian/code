    class Program
    {
        static void Main(string[] args)
        {
            Boolean Choose = false;
            string Input;
            Stats stats;
            MenuTacticus HubTacticus = new MenuTacticus();
    
            Console.WriteLine("Welcome to the PanaKnockOut Alpha V.");
            Console.WriteLine("There are three classes you can choose: Tacticus, Attacker, Defender \nEnter the name of the class to choose the class. \nFor more info about the classes enter ?");
            while (Choose == false){
                Console.WriteLine("What do you choose?");
                Console.WriteLine("");
                Input = (Console.ReadLine());
                Input.ToLower();
                switch (Input)
                {
                    case "tacticus":
                        Choose = true;
                        //Tactic = 60;
                        //Defend = 30;
                        //Attack = 30;
                        stats = new Stats(60,30,30);
                        HubTacticus.HubTacticus(stats);
                        break;
                    case "attacker":
                        //Tactic = 30;
                        //Defend = 30;
                        //Attack = 60;
                        stats = new Stats(30,30,60);
                        Choose = true;
                        break;
                    case "defender":
                        //Tactic = 30;
                        //Defend = 60;
                        //Attack = 30;
                        stats = new Stats(30,60,30);
                        Choose = true;
                        break;
                    default:
                        Console.WriteLine("This isn't a class at this moment.");
                        Console.WriteLine("Try Again!");
                        break;
                } 
            }
    
        }
    }
