    static void Main(string[] args)
          {
            int inlogpoging = 0;//initialize int counter
            while(inlogpoging<3)
            {
              if (inlogpoging == 3) //if equal to 3 then stop loguin process
              {
                Console.Clear();
                Console.WriteLine("Login limited.");
              }
              else {//if not 3 then process loguin
                Console.WriteLine("Status: " + status.Onaangemeld);
                Console.Write("Gebruikersnaam:");
                string Naam = Console.ReadLine();
                Console.Write("Wachtwoord:");
                string Wachtwoord = Console.ReadLine();
               //at this point increment counter
                inlogpoging++;
                if (Naam == "administrator" && Wachtwoord == "SHARPSOUND")
                {
                    Console.Clear();
                    Console.WriteLine("Status: " + status.Ingelogd);
                    Console.WriteLine("Welkom bij SoundSharp {0}!", Naam);
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Helaas, gebruikersnaam of wachtwoord niet     correct.");
                   //need a exit point
                   return 0;
                }
            }
          }
        }
