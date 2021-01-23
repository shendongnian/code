            Random r = new Random();
            int sum = 0;
            int count = 30;
            for (int i = 0; i < 30; i++)
            {
                var newNum = r.Next(1, 100);
                Console.WriteLine(newNum.ToString());
                sum += newNum;
            };
            Console.ReadLine();
            int avg = (int)sum / count;
            Console.WriteLine("The average is: {0}", avg);
            Console.ReadLine();
