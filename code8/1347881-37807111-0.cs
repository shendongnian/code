        class Program
        {
            const int MaxAttempt = 3;
            static int currentAttempt = 0;
    
            static void Main(string[] args)
            {
                if (MaxAttempt == currentAttempt)
                {
                    Console.WriteLine("You have reached maximum try .. please come after some time");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
    
                currentAttempt++;
    
                Console.WriteLine("Status: " + status.Onaangemeld);
                Console.WriteLine("Welkom, typ hieronder het gebruikersnaam:");
                string Naam = Console.ReadLine();
    
                Console.WriteLine("Vul hieronder het wachtwoord in:");
                string Wachtwoord = Console.ReadLine();
    
                if (Naam != "gebruiker" || Wachtwoord != "SHARPSOUND")
                {
                    Console.Clear();
                    Console.WriteLine("Helaas, gebruikersnaam of wachtwoord niet correct. Please try again");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                }
    
    
                Console.Clear();
                Console.WriteLine("Status: " + status.Ingelogd);
                Console.WriteLine("Welkom bij SoundSharp {0}!", Naam);
                Console.ReadLine();
    
    
            }
        }
