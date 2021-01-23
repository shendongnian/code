            Random r = new Random();
            int sum = 0;
            int count = 30;
            for (int i = 0; i < count; i++)
            {
                // Find your next random number
                var newNum = r.Next(1, 100);
                // Display it
                Console.WriteLine(newNum.ToString());
                // Add it to your running total
                sum += newNum;
            };
            Console.ReadLine();
            int avg = (int)sum / count;
            Console.WriteLine("The average is: {0}", avg);
            Console.ReadLine();
