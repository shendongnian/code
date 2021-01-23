      public static void PrintCounters(IEnumerable<Counter> counters)
        {
            foreach (Counter c in counters)
            {
                Console.WriteLine("{0} is {1}", c.Name, c.Address);
            }
        }
