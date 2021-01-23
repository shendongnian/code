    }
        while (nummervanappels != 15) {
            Console.WriteLine ("dat zijn er te weinig");
            System.Threading.Thread.Sleep (2000);
            Console.WriteLine ("raad opnieuw");
            System.Threading.Thread.Sleep (2000);
            nummervanappels = Convert.ToInt32 (Console.ReadLine ());
        }
