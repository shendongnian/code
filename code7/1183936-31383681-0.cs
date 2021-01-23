    class Program
        {
            public string[] Shooters = new string[4] { "B52", "Baby Guinness", "Bizu", "Jedi" };
            public List<string> Commande = new List<string>();
            static void Main(string[] args)
            {
                Random ran = new Random();
                Program shots = new Program();
                
                string name = null;
                
                
                name = Convert.ToString(ran.Next(0, shots.Shooters.Length));
                Sanction.DataContext = name;
                Commande.Add(name);
                Commande.Sort();
                ListeCommande.ItemsSource = Commande;    
            }
        }
