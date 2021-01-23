            int term = 72;
            double contractRate = 2.74 / 1200;
            double balance = 20203.66;
            double pmt = 304.96;
            double logarithm = 0;
            double power = 0;
            DateTime BeginLog = DateTime.UtcNow;
            for (int i = 0; i < 100000000; i++)
            {
                logarithm=(-1*Math.Log(1-(balance*contractRate/pmt))/Math.Log(1+contractRate));
            }
            DateTime EndLog = DateTime.UtcNow;
            Console.WriteLine("Elapsed time= " + (EndLog - BeginLog));
            Console.ReadLine();
            DateTime BeginPow = DateTime.UtcNow;
            for (int i = 0; i < 100000000; i++)
            {
                power = (balance * contractRate * Math.Pow(1 + contractRate, term)) / (Math.Pow(1 
                          +  contractRate, term) - 1);
            }
            DateTime EndPow = DateTime.UtcNow;
            Console.WriteLine("Elapsed time= " + (EndPow - BeginPow));
            Console.ReadLine();
