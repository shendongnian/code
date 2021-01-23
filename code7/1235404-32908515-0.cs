    //input data
            Console.Write("Number of Minutes spent Cycling...");
            int cycling = int.Parse(Console.ReadLine());
    //perform calculations
            TimeSpan cTime = TimeSpan.FromMinutes(cycling);
            string fromTimeString = cTime.ToString("h:mm");
    //output results
            Console.WriteLine("cycling {0}", fromTimeString);
            Console.ReadLine();
