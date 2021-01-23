    static void Main(string[] args)
    {
        string ConsoleReadinator;
        string MENU_TEXT = "Main Menu:";
        string ADDITIONAL_INFO = "Store or something";
        bool endProg = false;
        ConsoleReadinator = printMenu(MENU_TEXT, ADDITIONAL_INFO);
        // as long "EXIT" is not typed
        while (!endProg)
        {
            
            switch (ConsoleReadinator)
            {
                case "STORE":
                    // Do your Store Stuff
                    // maybe change MENU_TEXT and ADDITIONAL_INFO 
                    // and print a new Menu
                    ConsoleReadinator = printMenu(MENU_TEXT, ADDITIONAL_INFO);
                    break;
                case "GO":
                    // Do your Go Stuff
                    break;
                case "EXIT":
                    endProg = true;   // set exit condition to true
                    break;
                    
                default:                        
                    break;
            }
        }
        Console.ReadKey();
    }
    // one Method to use for Menu display
    public static string printMenu(string menuText, string additionalInfo)
    {
        Console.Clear();
        Console.WriteLine(menuText);
        Console.WriteLine(additionalInfo);
        return Console.ReadLine().ToUpper();
    }
