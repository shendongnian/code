            IList<IEnumerable<long>> manyNumbers = new List<IEnumerable<long>>();
            for (int i = 0; i < 16; i+=2)
            {
                manyNumbers.Add(Enumerable.Range(2 << i, 2 << (i + 1)).AsParallel().Select(a=> (long)a));
            }
            var parallel = manyNumbers.AsParallel();
            var allPrimes = parallel.SelectMany(sumNums =>
            {
                IEnumerable<long> somePrimes= sumNums.Where(num =>
               {
                   for (long i = 2; i <= Math.Sqrt(num); i++)
                   {
                       if (num % i == 0)
                       {
                           return false;
                       }
                   }
                   return true;
               }
                );
                return somePrimes;
            }
           
            );
            foreach (var number in allPrimes)
            {
                Console.WriteLine(number);
            }
            long sumOfPrimes = allPrimes.Sum();
            
            Console.WriteLine(sumOfPrimes);
            Console.ReadLine();
