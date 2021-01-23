            DateTime PowBeginTime = DateTime.UtcNow;
            for (int i = 0; i < 250000000; i++)
            {
                Math.Pow(1 + contractRate, term);
            }
            DateTime PowEndTime = DateTime.UtcNow;
            Console.WriteLine("Elapsed time= " + (PowEndTime - PowBeginTime));
            Console.ReadLine();
            DateTime HighSchoolBeginTime = DateTime.UtcNow;
            for (int i = 0; i < 250000000; i++)
            {
                Math.Exp(term * Math.Log(1 + contractRate));
            }
            DateTime HighSchoolEndTime = DateTime.UtcNow;
            Console.WriteLine("Elapsed time= " + (HighSchoolEndTime - HighSchoolBeginTime));
            Console.ReadLine();
