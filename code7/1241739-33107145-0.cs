    interface ConsoleInteractor
    {
        void performAction(string action);
    }
    class UserConsoleInteractor : ConsoleInteractor
    {
        public void performAction(string action)
        {
            switch(i)
            {
                case "create": 
                    Console.WriteLine("Created");
                    break;
                case "show":
                    Console.WriteLine("Showed");
                    break;
                default: 
                    Console.WriteLine("Default");
                    break;
            }
        }
    }
