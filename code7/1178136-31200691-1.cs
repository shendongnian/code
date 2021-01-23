            bool isInTime = false;
            var start = DateTime.Now;
            Console.WriteLine("answer this in 5 seconds, what is 2x2");
            var answer = Console.ReadLine();
            if ((DateTime.Now - start).TotalSeconds <= 5)
                isInTime = true;
            if (isInTime && answer == "4")
                Console.WriteLine("Good job you are now an agent");
            else
                Console.WriteLine("To slow and too dumb");
            Console.ReadKey();
