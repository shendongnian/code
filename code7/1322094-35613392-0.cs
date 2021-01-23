            DateTime weekly = DateTime.Now;
            TimeSpan timeToWait = new TimeSpan(0, 0, 0, 20); // days, hours, minutes, seconds
            while (DateTime.Now.Subtract(weekly) < timeToWait)
            {
                System.Threading.Thread.Sleep(1000); //sleep 1 second while waiting so cpu doesn't spin at maximum
            }
            Console.WriteLine($"{timeToWait.TotalSeconds} seconds have elapsed.");
