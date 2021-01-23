        static void Main(string[] args)
        {
            try
            {
                CeliusToFahrentheit ctf = new CeliusToFahrentheit();
                ctf.Celius = 100;
                Console.WriteLine(ctf.Fahrentheit);
                string mesg = ctf.ToString();
                Console.WriteLine(mesg);
