    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            enum Policy
            {
                A, B, C
            }
            struct Row
            {
                public Policy p;
                public int commission;
            }
            static void Main(string[] args)
            {
                const int MAX = 100;
                List<Row> rows = new List<Row>(MAX);
                Random rand = new Random(0);
                for (int x=0; x < MAX; x++)
                {
                    int policy = rand.Next(3);
                    int comm = rand.Next(1000);
                    rows.Add(new Row() { p = (Policy)policy, commission = comm });
                }
                var query = rows.GroupBy(row => row.p, (policy, r) => new { Policy = policy, Sum = r.Sum(t => t.commission) });
                foreach(var result in query)
                {
                    Console.WriteLine(result.Policy + ": " + result.Sum);
                }
                Console.ReadLine();
            }
        }
    }
