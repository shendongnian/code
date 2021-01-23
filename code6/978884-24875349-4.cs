        static void Main(string[] args)
        {
            
            ConcurrentDictionary<int, int> resultDictionary = new ConcurrentDictionary<int, int>();
            Parallel.For(0, 1000, x =>
            {
                var r = RandomProvider.GetThreadRandom();
                ConcurrentDictionary<string, int> dictionary = new ConcurrentDictionary<string, int>();
                    while (true)
                    {
                        int rand = r.Next(0, 1073741823);
                        CrockfordBase32Encoding encoding = new CrockfordBase32Encoding();
                        string encodedRand = encoding.Encode((ulong) rand, false);
                        if (!dictionary.TryAdd(encodedRand, rand)) break;
                    }
                Console.WriteLine("{0} - {1}", x, dictionary.Count);
                resultDictionary.TryAdd(x, dictionary.Count);
            });
            Console.WriteLine();
            Console.WriteLine("Average Number Before Duplicate: " + resultDictionary.Average(x => x.Value));
            Console.WriteLine("Minimum Number Before Duplicate: " + resultDictionary.Min(x => x.Value));
            Console.WriteLine("Maximum Number Before Duplicate: " + resultDictionary.Max(x => x.Value));
            Console.WriteLine(" Median Number Before Duplicate: " + resultDictionary.Select(x=>x.Value).Median());
            Console.ReadLine();
        }
