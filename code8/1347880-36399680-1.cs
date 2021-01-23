    static void Main(string[] args)
    {
        for (int i=0; i<3; i++) 
        {
            Console.WriteLine("Status: " + status.Onaangemeld);
            Console.WriteLine("Welkom, typ hieronder het gebruikersnaam:");
            string Naam = Console.ReadLine();
            Console.WriteLine("Vul hieronder het wachtwoord in:");
            string Wachtwoord = Console.ReadLine();
            if (Naam == "gebruiker" && Wachtwoord == "SHARPSOUND")
            {
                Console.Clear();
                Console.WriteLine("Status: " + status.Ingelogd);
                Console.WriteLine("Welkom bij SoundSharp {0}!", Naam);
                Console.ReadLine();
                break;
            }
            Console.Clear();
            Console.WriteLine("Helaas, gebruikersnaam of wachtwoord niet correct.");
            
        }
        Console.Clear();
        Console.WriteLine("....");
    }
  }
